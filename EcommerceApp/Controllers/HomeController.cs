using System.Diagnostics;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public async Task<IActionResult> Index(int page = DefaultPageNumber, int pageSize = DefaultPageSize)
        {
            var products = await productService.GetAllProductsAsync(page, pageSize);

            return View(products);
        }

        public async Task<IActionResult> Popular(int page = DefaultPageNumber, int pageSize = DefaultPageSize)
        {
            var popularProducts = await productService.GetPopularProductsAsync(page, pageSize);
            ViewBag.ActionName = "Popular";
            return View("Index", popularProducts);
        }

        public async Task<IActionResult> NewArrivals(int page = DefaultPageNumber, int pageSize = DefaultPageSize)
        {
            var newArrivals = await productService.GetNewArrivalsAsync(page, pageSize);
            ViewBag.ActionName = "NewArrivals";
            return View("Index", newArrivals);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
