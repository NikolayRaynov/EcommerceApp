using EcommerceApp.Web.ViewModels.Cart;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface ICartService
    {
        Task<CartIndexViewModel> GetUserCartAsync(string userId);
        Task AddProductToCartAsync(int productId, string userId);
        Task IncreaseProductQuantityAsync(int productId, string userId);
        Task DecreaseProductQuantityAsync(int productId, string userId);
        Task RemoveProductFromCartAsync(int productId, string userId);
    }
}