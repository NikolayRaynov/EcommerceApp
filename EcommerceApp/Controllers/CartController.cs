using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly IProductService productService;

        public CartController(ICartService cartService, IProductService productService)
        {
            this.cartService = cartService;
            this.productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await this.cartService.GetUserCartAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.cartService.AddProductToCartAsync(productId, userId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> IncreaseQuantity(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.cartService.IncreaseProductQuantityAsync(id, userId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DecreaseQuantity(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.cartService.DecreaseProductQuantityAsync(id, userId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.cartService.RemoveProductFromCartAsync(id, userId);

            return RedirectToAction(nameof(Index));
        }
    }
}