using EcommerceApp.Web.ViewModels.Product;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface IFavoriteProductService
    {
        Task<bool> AddToFavoritesAsync(int productId, string userId);
        Task RemoveFromFavoritesAsync(int productId, string userId);
        Task<bool> IsInFavoriteAsync(int productId, string userId);
        Task<IEnumerable<ProductIndexViewModel>> GetAllFavoritesAsync(string userId);
    }
}
