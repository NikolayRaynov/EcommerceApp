using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Category;
using EcommerceApp.Web.ViewModels.Product;
using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRoleName)]
    [Area(AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IRepository repository;
        private readonly ICategoryService categoryService;
        private readonly IHtmlSanitizer htmlSanitizer;

        public ProductController(IProductService productService, 
                                 IRepository repository, 
                                 ICategoryService categoryService, 
                                 IHtmlSanitizer htmlSanitizer)
        {
            this.productService = productService;
            this.repository = repository;
            this.categoryService = categoryService;
            this.htmlSanitizer = htmlSanitizer;
        }

        [HttpGet]
        [AllowAnonymous]
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


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllAsync();

            var viewModel = new AddProductViewModel
            {
                Categories = categories
                    .Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productService.AddProductAsync(model, model.Images.ToList());
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException)
                {
                    return RedirectToAction("Error", "Home", new { statusCode = 404 });
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home", new { statusCode = 500 });
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await productService.GetProductForEditAsync(id);
            if (product == null)
            {
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }

            var viewModel = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrls = product.ImageUrls.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model, List<IFormFile> newImages)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productService.UpdateProductAsync(model, newImages);
                }
                catch (UnauthorizedAccessException)
                {
                    return RedirectToAction("Error", "Home", new { statusCode = 403 });
                }
                catch (InvalidOperationException)
                {
                    return RedirectToAction("Error", "Home", new { statusCode = 404 });
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home", new { statusCode = 500 });
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await productService.GetProductForDeleteAsync(id);
                if (product == null)
                {
                    return RedirectToAction("Error", "Home", new { statusCode = 404 });
                }

                var viewModel = new DeleteProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrls = product.ImageUrls
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { statusCode = 500 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteProductViewModel model)
        {
            try
            {
                await productService.DeleteProductAsync(model.Id);
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Error", "Home", new { statusCode = 403 });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { statusCode = 500 });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var product = await productService.GetProductByIdAsync(id);

                if (product == null)
                {
                    return RedirectToAction("Error", "Home", new { statusCode = 404 });
                }

                var viewModel = new ProductDetailsViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrls = product.ImageUrls,
                    Reviews = product.Reviews
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { statusCode = 500 });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Popular()
        {
            var popularProducts = await productService.GetPopularProductsAsync();
            return View($"~{DefaultViewPath}", popularProducts);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> NewArrivals()
        {
            var newArrivals = await productService.GetNewArrivalsAsync();
            return View($"~{DefaultViewPath}", newArrivals);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(int id, string imageUrl)
        {
            try
            {
                await productService.DeleteImageAsync(id, imageUrl);
                return RedirectToAction(nameof(Edit), new { id });
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Error", "Home", new { statusCode = 403 });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { statusCode = 500 });
            }
        }
    }
}
