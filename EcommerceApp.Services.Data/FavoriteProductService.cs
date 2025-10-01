using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Product;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Services.Data
{
    public class FavoriteProductService : IFavoriteProductService
    {
        private readonly IRepository repository;

        public FavoriteProductService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddToFavoritesAsync(int productId, string userId)
        {
            var existInFavorites = await this.repository
                .All<FavoriteProduct>()
                .Include(fp => fp.Products)
                .FirstOrDefaultAsync(fp => fp.UserId == userId && fp.Products
                .Any(p => p.Id == productId));

            if (existInFavorites != null)
            {
                return false;
            }

            var favoriteProducts = await this.repository
                .All<FavoriteProduct>()
                .Include(fp => fp.Products)
                .FirstOrDefaultAsync(fp => fp.UserId == userId);

            if (favoriteProducts == null)
            {
                favoriteProducts = new FavoriteProduct
                {
                    UserId = userId,
                    Products = new List<Product>()
                };

                await this.repository.AddAsync(favoriteProducts);
            }

            var product = await this.repository
                .GetByIdAsync<Product>(productId);

            if (product != null)
            {
                favoriteProducts.Products.Add(product);
            }

            await this.repository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductIndexViewModel>> GetAllFavoritesAsync(string userId)
        {
            var favorites = await this.repository
                .AllReadonly<FavoriteProduct>()
                .Where(fp => fp.UserId == userId)
                .Include(fp => fp.Products)
                .ThenInclude(p => p.Images)
                .SelectMany(fp => fp.Products)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrls = p.Images
                        .Select(i => i.Url)
                        .ToList()
                })
                .ToListAsync();

            return favorites;
        }

        public async Task<bool> IsInFavoriteAsync(int productId, string userId)
        {
            var isInFavorites = await this.repository
                .All<FavoriteProduct>()
                .AnyAsync(fp => fp.UserId == userId && fp.Products
                .Any(p => p.Id == productId));

            return isInFavorites;
        }

        public async Task RemoveFromFavoritesAsync(int productId, string userId)
        {
            var favoriteProducts = await this.repository
                .All<FavoriteProduct>()
                .Include(fp => fp.Products)
                .FirstOrDefaultAsync(fp => fp.UserId == userId);

            if (favoriteProducts == null)
            {
                throw new InvalidOperationException("This product is not in your favorites.");
            }

            var productForRemove = favoriteProducts.Products
                .FirstOrDefault(p => p.Id == productId);

            if (productForRemove != null)
            {
                favoriteProducts.Products.Remove(productForRemove);
            }

            if (!favoriteProducts.Products.Any())
            {
                repository.Delete(favoriteProducts);
            }
            else
            {
                repository.Update(favoriteProducts);
            }

            await this.repository.SaveChangesAsync();
        }
    }
}
