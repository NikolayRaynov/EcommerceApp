using EcommerceApp.Web.ViewModels.Order;

namespace EcommerceApp.Web.ViewModels.Admin
{
    public class AdminDashboardViewModel
    {
        public int TotalOrders { get; set; }
        public int TotalUsers { get; set; }
        public int TotalProducts { get; set; }
        public decimal TotalRevenue { get; set; }
        public ICollection<OrderHistoryViewModel> RecentOrders { get; set; } = 
            new List<OrderHistoryViewModel>();
    }
}
