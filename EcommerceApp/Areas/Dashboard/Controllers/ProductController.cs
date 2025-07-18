using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
