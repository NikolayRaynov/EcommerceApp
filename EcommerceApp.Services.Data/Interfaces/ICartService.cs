using EcommerceApp.Web.ViewModels.Cart;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface ICartService
    {
        Task<CartIndexViewModel> GetUserCartAsync(string userId);
        Task AddProductToCartAsync(int productId, string userId);
        Task IncreaseProductQuantityAsync(int cartItemId);
        Task DecreaseProductQuantityAsync(int cartItemId);
        Task RemoveProductFromCartAsync(int cartItemId);
    }
}