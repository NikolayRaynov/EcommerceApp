using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Areas.Dashboard.Controllers
{
    //[Authorize]
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IRepository repository;

        public ProductController(IProductService productService, IRepository repository)
        {
            this.productService = productService;
            this.repository = repository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAllProductsAsync();
            return View(products);
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
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);

                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), DefaultImagePath)))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), DefaultImagePath));
                }

                var savePath = Path.Combine(Directory.GetCurrentDirectory(), DefaultImagePath, imageName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }

                model.Image = $"/images/Products/{imageName}";

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
                    if (model.ImageFile != null)
                    {
                        var imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);

                        if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), DefaultImagePath)))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), DefaultImagePath));
                        }

                        var savePath = Path.Combine(Directory.GetCurrentDirectory(), DefaultImagePath, imageName);
                        using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            await model.ImageFile.CopyToAsync(stream);
                        }

                        model.Image = $"/images/Products/{imageName}";
                    }

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
        public async Task<IActionResult> Delete(int id)
        {
            var product = await this.productService.GetProductForDeleteAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new DeleteProductViewModel
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
        public async Task<IActionResult> Delete(DeleteProductViewModel model)
        {
            try
            {
                await this.productService.DeleteProductAsync(model.Id);
            }
            catch (Exception)
            {
                return NotFound();
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
