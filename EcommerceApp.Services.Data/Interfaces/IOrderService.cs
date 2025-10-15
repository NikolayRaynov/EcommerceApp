using EcommerceApp.Common.Enums;
using EcommerceApp.Web.ViewModels.Order;
using EcommerceApp.Web.ViewModels.Product;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(string userId, OrderCheckoutViewModel model);
        Task<ICollection<OrderHistoryViewModel>> GetUserOrderAsync(string userId);
        Task<OrderDetailViewModel> GetOrderDetailAsync(int orderId, string userId);
        Task<decimal> GetTotalAmountAsync(string userId);
        Task<int> GetTotalOrdersCountAsync();
        Task<decimal> GetTotalRevenueAsync();
        Task<ICollection<OrderHistoryViewModel>> GetRecentOrdersAsync(int count);
        Task<IEnumerable<OrderStatusCountViewModel>> GetOrderStatusDistributionAsync();
        Task<IEnumerable<TopSellingProductsViewModel>> GetTopSellingProductsAsync(int topSellingCount);
        Task<OrderCheckoutViewModel> GetCheckoutDetailsAsync(string userId);
        Task ClearUserCartAsync(string userId);
        Task UpdateUserOrderStatusAsync(int orderId, OrderStatus status);
    }
}