using EcommerceApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int? categoryId, int pageNumber = DefaultPageNumber)
        {
            try
            {
                var allCategories = await categoryService.GetAllAsync();

                ViewBag.Categories = new SelectList(allCategories, "Id", "Name", categoryId);
                ViewBag.SelectedCategoryId = categoryId;

                var products = await productService.GetAllProductsAsync(pageNumber, DefaultPageSize, categoryId);
                return View(products);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }

        public async Task<IActionResult> Popular(int? categoryId, int pageNumber = DefaultPageNumber)
        {
            try
            {
                var allCategories = await categoryService.GetAllAsync();

                ViewBag.Categories = new SelectList(allCategories, "Id", "Name", categoryId);
                ViewBag.SelectedCategoryId = categoryId;

                var popularProducts = await productService.GetPopularProductsAsync(pageNumber, DefaultPageSize, categoryId);
                ViewBag.ActionName = "Popular";
                return View("Index", popularProducts);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }

        public async Task<IActionResult> NewArrivals(int? categoryId, int pageNumber = DefaultPageNumber)
        {
            try
            {
                var allCategories = await categoryService.GetAllAsync();

                ViewBag.Categories = new SelectList(allCategories, "Id", "Name", categoryId);
                ViewBag.SelectedCategoryId = categoryId;

                var newArrivals = await productService.GetNewArrivalsAsync(pageNumber, DefaultPageSize, categoryId);
                ViewBag.ActionName = "NewArrivals";
                return View("Index", newArrivals);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult License()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error(int? statusCode = null)
        {
            if (!statusCode.HasValue)
            {
                return this.View();
            }

            if (statusCode == 404)
            {
                return this.View("Error404");
            }
            else if (statusCode == 401 || statusCode == 403)
            {
                return this.View("Error403");
            }

            return this.View("Error500");
        }
    }
}