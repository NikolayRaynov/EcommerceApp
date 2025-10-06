using EcommerceApp.Web.ViewModels.Order;
using EcommerceApp.Web.ViewModels.Product;

namespace EcommerceApp.Web.ViewModels.Admin
{
    public class AdminDashboardViewModel
    {
        public int TotalOrders { get; set; }
        public int TotalUsers { get; set; }
        public decimal TotalRevenue { get; set; }
        public IEnumerable<ProductsByCategoryViewModel> ProductsByCategory { get; set; } 
            = new List<ProductsByCategoryViewModel>();
        public ICollection<OrderHistoryViewModel> RecentOrders { get; set; } 
            = new List<OrderHistoryViewModel>();
    }
}
