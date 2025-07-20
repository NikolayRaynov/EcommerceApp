using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceApp.Areas.Dashboard.Controllers
{
    [Authorize]
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var products = await productService.GetAllProductsAsync();
            var model = new AddProductViewModel
            {
                Name = string.Empty,
                Description = string.Empty,
                Price = 0.0m,
                Image = string.Empty
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await this.productService.AddProductAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await this.productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image
            };

            return View(viewModel);
        }
    }
}
