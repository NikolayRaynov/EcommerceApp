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

        public async Task<IEnumerable<ProductIndexViewModel>> GetAllProductsAsync(int page = DefaultPageNumber, 
            int pageSize = DefaultPageSize, string? searchTerm = null)
        {
            var query = this.repository.AllReadonly<Product>();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
            }

            var products = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var productViewModels = new List<ProductIndexViewModel>();

            foreach (var product in products)
            {
                productViewModels.Add(new ProductIndexViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Image = product.Image
                });
            }

            return productViewModels;
        }

        public async Task<int> AddProductAsync(AddProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Image = model.Image
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
                Name = product.Name
            };
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await this.repository.GetByIdAsync<Product>(productId);

            if (product == null)
            {
                return false;
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

        public async Task<ProductIndexViewModel?> GetByIdAsync(int productId)
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
    }
}
