using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcommerceApp.Areas.Dashboard.Controllers
{
    [Authorize]
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IRepository repository;

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
        public async Task<IActionResult> Edit(int id)
        {
            var product = await productService.GetProductForEditAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    await this.productService.UpdateProductAsync(model);
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }

            return RedirectToAction(nameof(Index));
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

        private bool ProductExists(int id)
        {
            return repository.All<Product>().Any(e => e.Id == id);
        }
    }
}
