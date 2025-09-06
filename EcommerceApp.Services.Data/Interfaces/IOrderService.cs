using EcommerceApp.Web.ViewModels.Order;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(string userId, OrderCheckoutViewModel model);
        Task<ICollection<OrderHistoryViewModel>> GetUserOrderAsync(string userId);
        Task<OrderDetailViewModel> GetOrderDetailAsync(int orderId, string userId);
        Task<decimal> GetTotalAmountAsync(string userId);
    }
}
