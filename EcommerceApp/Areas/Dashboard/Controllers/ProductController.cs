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
                model.Image = await UploadImageAsync(model.ImageFile);
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
                        model.Image = await UploadImageAsync(model.ImageFile);
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
            var product = await this.productService.GetProductByIdAsync(id);

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
        private async Task<string> UploadImageAsync(IFormFile imageFile)
        {
            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), DefaultImagePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var savePath = Path.Combine(directoryPath, imageName);

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"/images/Products/{imageName}";
        }
    }
}
