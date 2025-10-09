using EcommerceApp.Web.ViewModels.Order;
using EcommerceApp.Web.ViewModels.Product;

namespace EcommerceApp.Web.ViewModels.Admin
{
    public class AdminDashboardViewModel
    {
        public IEnumerable<TopSellingProductsViewModel> TopSellingProducts { get; set; }
            = new List<TopSellingProductsViewModel>();
        public IEnumerable<OrderStatusCountViewModel> OrderStatusDistribution { get; set; }
            = new List<OrderStatusCountViewModel>();
        public IEnumerable<ProductsLowStockQuantity> LowStockQuantities { get; set; }
            = new List<ProductsLowStockQuantity>();
        public IEnumerable<ProductsByCategoryViewModel> ProductsByCategory { get; set; }
            = new List<ProductsByCategoryViewModel>();
        public ICollection<OrderHistoryViewModel> RecentOrders { get; set; }
            = new List<OrderHistoryViewModel>();
    }
}