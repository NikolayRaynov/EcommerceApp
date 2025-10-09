using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRoleName)]
    [Area(AdminRoleName)]
    public class HomeController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;
        private readonly IProductService productService;

        public HomeController(
            IOrderService orderService,
            IUserService userService,
            IProductService productService)
        {
            this.orderService = orderService;
            this.userService = userService;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var topSellingProducts = await this.orderService.GetTopSellingProductsAsync(5);
            var orderStatusDistribution = await this.orderService.GetOrderStatusDistributionAsync();
            var productsByCategory = await this.productService.GetProductCountByCategoryAsync();
            var lowStockQuantity = await this.productService.GetLowStockProducts();

            var recentOrders = await this.orderService.GetRecentOrdersAsync(10);

            var model = new AdminDashboardViewModel
            {
                TopSellingProducts = topSellingProducts,
                OrderStatusDistribution = orderStatusDistribution,
                ProductsByCategory = productsByCategory,
                LowStockQuantities = lowStockQuantity,
                RecentOrders = recentOrders
            };

            return View(model);
        }
    }
}