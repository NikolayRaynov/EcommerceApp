using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Product;
using Ganss.Xss;
using MailKit.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly IRepository repository;
        private readonly ICategoryService categoryService;
        private readonly IHtmlSanitizer htmlSanitizer;
        private readonly IFileService fileService;
        private readonly UserManager<ApplicationUser> userManager;
        public ProductService(IRepository repository, ICategoryService categoryService, 
            IHtmlSanitizer htmlSanitizer, IFileService fileService, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.categoryService = categoryService;
            this.htmlSanitizer = htmlSanitizer;
            this.fileService = fileService;
            this.userManager = userManager;
        }

        public async Task<ProductPageViewModel> GetAllProductsAsync(int pageNumber = DefaultPageNumber, 
            int pageSize = DefaultPageSize, int? categoryId = null)
        {
            var query = this.repository.AllReadonly<Product>();

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(d => d.CategoryId == categoryId.Value);
            }

            var totalProducts = await query.CountAsync();

            var productsOnPage = await query
                .OrderBy(d => d.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(d => d.Images)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrls = p.Images.Select(i => i.Url).ToList(),
                    CreatedOn = p.CreatedOn
                })
                .ToListAsync();

            int totalPages = 0;
            if (pageSize > 0)
            {
                totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
            }

            var viewModel = new ProductPageViewModel
            {
                Products = productsOnPage,
                TotalCount = totalProducts,
                PageNumber = pageNumber,
                TotalPages = totalPages
            };

            return viewModel;
        }

        public async Task AddProductAsync(AddProductViewModel model, List<IFormFile> images)
        {
            ValidateImages(images);

            var product = new Product
            {
                Name = htmlSanitizer.Sanitize(model.Name),
                Description = htmlSanitizer.Sanitize(model.Description),
                CategoryId = model.CategoryId,
                Price = model.Price,
                CreatedOn = DateTime.UtcNow
            };

            var imageUrls = await SaveImages(images, model.CategoryId);

            foreach (var imageUrl in imageUrls)
            {
                product.Images.Add(new Image { Url = imageUrl });
            }

            await this.repository.AddAsync(product);
            await this.repository.SaveChangesAsync();
        }

        public async Task<EditProductViewModel?> GetProductForEditAsync(int productId)
        {
            var product = await this.repository
                .AllReadonly<Product>()
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                return null;
            }

            return new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrls = product.Images.Select(i => i.Url).ToList()
            };
        }

        public async Task<bool> UpdateProductAsync(EditProductViewModel model, List<IFormFile> newImages)
        {
            var product = await this.repository.GetByIdAsync<Product>(model.Id);

            if (product == null)
            {
                return false;
            }

            product.Name = htmlSanitizer.Sanitize(model.Name);
            product.Description = htmlSanitizer.Sanitize(model.Description);
            product.Price = model.Price;

            if (newImages != null && newImages.Count > 0)
            {
                var imageUrls = await SaveImages(newImages, product.CategoryId);
                foreach (var imageUrl in imageUrls)
                {
                    product.Images.Add(new Image { Url = imageUrl });
                }
            }

            this.repository.Update(product);
            await this.repository.SaveChangesAsync();

            return true;
        }

        public async Task<DeleteProductViewModel?> GetProductForDeleteAsync(int productId)
        {
            var product = await this.repository
                .AllReadonly<Product>()
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                return null;
            }

            return new DeleteProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrls = product.Images.Select(i => i.Url).ToList()
            };
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await this.repository
                .All<Product>()
                .Include(d => d.Images)
                .Include(d => d.Reviews)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product != null)
            {
                repository.DeleteRange<Review>(r => r.ProductId == productId);
                await repository.SaveChangesAsync();

                repository.DeleteRange<CartProduct>(cp => cp.ProductId == productId);
                await repository.SaveChangesAsync();

                var category = await categoryService.GetByIdAsync(product.CategoryId);
                if (category == null)
                {
                    throw new InvalidOperationException("The category is not found.");
                }

                var categoryFolder = fileService.SanitizeFolderName(category.Name);

                foreach (var image in product.Images)
                {
                    var fileName = Path.GetFileName(image.Url);
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), UrlPath, categoryFolder).ToLower();
                    var filePath = Path.Combine(folderPath, fileName).ToLower();

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }

                repository.Delete(product);
                await repository.SaveChangesAsync();
            }
        }

        public async Task<ProductIndexViewModel?> GetProductByIdAsync(int productId)
        {
            var product = await this.repository
                .AllReadonly<Product>()
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                return null;
            }

            return new ProductIndexViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrls = product.Images.Select(i => i.Url).ToList()
            };
        }

        public async Task<ProductPageViewModel> GetPopularProductsAsync(int pageNumber = DefaultPageNumber,
            int pageSize = DefaultPageSize, int? categoryId = null)
        {
            IQueryable<Product> query = this.repository
                .AllReadonly<Product>()
                .Include(p => p.OrderProducts)
                .Where(p => p.OrderProducts.Sum(op => op.Quantity) >= 3);

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(d => d.CategoryId == categoryId.Value);
            }

            query = query.OrderByDescending(p => p.OrderProducts.Sum(op => op.Quantity));

            var totalProducts = await query.CountAsync();

            var productsOnPage = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(d => d.Images)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrls = p.Images.Select(i => i.Url).ToList(),
                    CreatedOn = p.CreatedOn
                })
                .ToListAsync();

            int totalPages = 0;
            if (pageSize > 0)
            {
                totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
            }

            var viewModel = new ProductPageViewModel
            {
                Products = productsOnPage,
                TotalCount = totalProducts,
                PageNumber = pageNumber,
                TotalPages = totalPages
            };

            return viewModel;
        }

        public async Task<ProductPageViewModel> GetNewArrivalsAsync(int pageNumber = DefaultPageNumber,
            int pageSize = DefaultPageSize, int? categoryId = null)
        {
            var lastMonth = DateTime.UtcNow.AddMonths(-1);

            IQueryable<Product> query = this.repository
                .AllReadonly<Product>()
                .Where(p => p.CreatedOn >= lastMonth);

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(d => d.CategoryId == categoryId.Value);
            }

            query = query.OrderByDescending(p => p.CreatedOn);
            var totalProducts = await query.CountAsync();

            var productsOnPage = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(d => d.Images)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrls = p.Images.Select(i => i.Url).ToList(),
                    CreatedOn = p.CreatedOn
                })
                .ToListAsync();

            int totalPages = 0;
            if (pageSize > 0)
            {
                totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
            }

            var viewModel = new ProductPageViewModel
            {
                Products = productsOnPage,
                TotalCount = totalProducts,
                PageNumber = pageNumber,
                TotalPages = totalPages
            };

            return viewModel;
        }

        public async Task DeleteImageAsync(int productId, string imageUrl)
        {
            var product = await repository.All<Product>()
                .Include(d => d.Images)
                .FirstOrDefaultAsync(d => d.Id == productId);

            if (product != null)
            {
                var imageToDelete = product.Images.FirstOrDefault(i => i.Url == imageUrl);

                if (imageToDelete != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), DefaultFolder, imageUrl.TrimStart('/'));
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    repository.Delete(imageToDelete);
                    await repository.SaveChangesAsync();
                }
            }
        }

        private async Task<List<string>> SaveImages(List<IFormFile> images, int categoryId)
        {
            var category = await categoryService.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new InvalidOperationException("The category is not found.");
            }

            var categoryFolder = fileService.SanitizeFolderName(category.Name);
            var imageUrls = new List<string>();

            foreach (var image in images)
            {
                var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();
                if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png")
                {
                    var fileName = Guid.NewGuid().ToString() + fileExtension;
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), UrlPath, categoryFolder);
                    Directory.CreateDirectory(folderPath);
                    var filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    imageUrls.Add($"/images/{categoryFolder}/{fileName}");
                }
                else
                {
                    throw new InvalidOperationException("Invalid image. Please upload a .jpg, .jpeg or .png file.");
                }
            }

            return imageUrls;
        }

        private void ValidateImages(List<IFormFile> images)
        {
            foreach (var image in images)
            {
                if (image.Length > 5 * 1024 * 1024)
                {
                    throw new InvalidOperationException("Please upload image up to 5MB.");
                }
            }
        }
    }
}
