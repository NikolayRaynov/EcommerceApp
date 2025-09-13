using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly IRepository repository;

        public ProductService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ProductPageViewModel> GetAllProductsAsync(int pageNumber = DefaultPageNumber, 
            int pageSize = DefaultPageSize, string? searchTerm = null)
        {
            var query = this.repository.AllReadonly<Product>();

            query = query.OrderBy(p => p.Id);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
            }

            var totalProducts = await query.CountAsync();

            var productsOnPage = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Image = p.Image,
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

        public async Task<int> AddProductAsync(AddProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Image = model.Image,
                CreatedOn = DateTime.UtcNow
            };

            await this.repository.AddAsync(product);
            await this.repository.SaveChangesAsync();

            return product.Id;
        }

        public async Task<EditProductViewModel?> GetProductForEditAsync(int productId)
        {
            var product = await this.repository.GetByIdAsync<Product>(productId);

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
                Image = product.Image
            };
        }

        public async Task<bool> UpdateProductAsync(EditProductViewModel model)
        {
            var product = await this.repository.GetByIdAsync<Product>(model.Id);

            if (product == null)
            {
                return false;
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Image = model.Image;

            this.repository.Update(product);
            await this.repository.SaveChangesAsync();

            return true;
        }

        public async Task<DeleteProductViewModel?> GetProductForDeleteAsync(int productId)
        {
            var product = await this.repository.GetByIdAsync<Product>(productId);

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
                Image = product.Image
            };
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await this.repository.All<Product>().FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                return false;
            }

            var cartProducts = await this.repository
                .All<CartProduct>()
                .Where(cp => cp.ProductId == productId)
                .ToListAsync();

            if (cartProducts.Any())
            {
                this.repository.DeleteRange(cartProducts);
            }

            string productImagePath = Path.Combine(Directory.GetCurrentDirectory(), 
                DefaultImagePath, Path.GetFileName(product.Image));

            if (File.Exists(productImagePath))
            {
                File.Delete(productImagePath);
            }

            this.repository.Delete(product);
            await this.repository.SaveChangesAsync();

            return true;
        }

        public async Task<int> GetProductCountAsync(string? searchTerm = null)
        {
            var query = this.repository.AllReadonly<Product>();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
            }

            return await query.CountAsync();
        }

        public async Task<ProductIndexViewModel?> GetProductByIdAsync(int productId)
        {
            var product = await this.repository.All<Product>()
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
                Image = product.Image
            };
        }

        public async Task<ProductPageViewModel> GetPopularProductsAsync(int pageNumber = DefaultPageNumber, int pageSize = DefaultPageSize)
        {
            var query = this.repository.AllReadonly<Product>()
                .Where(p => p.OrderProducts.Sum(op => op.Quantity) >= 3)
                .OrderByDescending(p => p.OrderProducts.Sum(op => op.Quantity));

            var totalProducts = await query.CountAsync();

            var productsOnPage = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Image = p.Image,
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

        public async Task<ProductPageViewModel> GetNewArrivalsAsync(int pageNumber = DefaultPageNumber, int pageSize = DefaultPageSize)
        {
            var lastMonth = DateTime.UtcNow.AddMonths(-1);

            var query = this.repository.AllReadonly<Product>()
                .Where(p => p.CreatedOn >= lastMonth)
                .OrderByDescending(p => p.CreatedOn);

            var totalProducts = await query.CountAsync();

            var productsOnPage = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Image = p.Image,
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
    }
}
