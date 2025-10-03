using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.FavoritePlace;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceApp.Controllers
{
    public class FavoriteProductController : Controller
    {
        private readonly IFavoriteProductService favoriteProductService;
        private readonly IProductService productService;

        public FavoriteProductController(IFavoriteProductService favoriteProductService, IProductService productService)
        {
            this.favoriteProductService = favoriteProductService;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var favoriteProducts = await this.favoriteProductService.GetAllFavoritesAsync(userId);

                return View(favoriteProducts);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add(int productId)
        {
            var product = await this.productService.GetProductByIdAsync(productId);

            if (product == null)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 404 });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (await this.favoriteProductService.IsInFavoriteAsync(productId, userId))
            {
                TempData["ErrorMessage"] = "This product is already in your favorites.";
                return RedirectToAction(nameof(Index), "Product");
            }

            var viewModel = new AddToFavoriteViewModel
            {
                ProductId = productId,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductImageUrls = product.ImageUrls,
                ProductPrice = product.Price
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddToFavoriteViewModel model)
        {
            if (model.ProductId <= 0)
            {
                TempData["ErrorMessage"] = "Invalid product.";
                return RedirectToAction(nameof(Index), "Product");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var success = await favoriteProductService.AddToFavoritesAsync(model.ProductId, userId);

                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "An error occurred while adding the product to your favorites.";
                    return RedirectToAction(nameof(Index), "Product");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await productService.GetProductByIdAsync(id);

                if (product == null)
                {
                    return RedirectToAction("Error", "Home", new { area = "", statusCode = 404 });
                }

                var viewModel = new DeleteFavoriteViewModel
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductDescription = product.Description,
                    ProductImageUrls = product.ImageUrls
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteFavoriteViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await favoriteProductService.RemoveFromFavoritesAsync(model.ProductId, userId);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }
    }
}
