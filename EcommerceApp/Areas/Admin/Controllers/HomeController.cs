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
            var totalOrders = await this.orderService.GetTotalOrdersCountAsync();
            var totalUsers = await this.userService.GetTotalUsersCountAsync();
            var totalProducts = await this.productService.GetProductCountAsync();
            var totalRevenue = await this.orderService.GetTotalRevenueAsync();

            var recentOrders = await this.orderService.GetRecentOrdersAsync(10);

            var model = new AdminDashboardViewModel
            {
                TotalOrders = totalOrders,
                TotalUsers = totalUsers,
                TotalProducts = totalProducts,
                TotalRevenue = totalRevenue,
                RecentOrders = recentOrders
            };

            return View(model);
        }
    }
}
