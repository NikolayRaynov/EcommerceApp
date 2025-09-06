using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;

        public OrderController(IOrderService orderService, ICartService cartService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await this.cartService.GetUserCartAsync(userId);

            if (cart == null || !cart.CartItems.Any())
            {
                TempData["ErrorMessage"] = "Your cart is empty and cannot be checked out.";
                return RedirectToAction(nameof(Index), "Cart");
            }

            var model = new OrderCheckoutViewModel();
            model.TotalAmount = await this.orderService.GetTotalAmountAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderCheckoutViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await this.cartService.GetUserCartAsync(userId);

            if (cart == null || !cart.CartItems.Any())
            {
                TempData["ErrorMessage"] = "Your cart is empty and cannot be checked out.";
                return RedirectToAction(nameof(Index), "Cart");
            }

            if (!ModelState.IsValid)
            {
                model.TotalAmount = await this.orderService.GetTotalAmountAsync(userId);
                return View(model);
            }

            try
            {
                await this.orderService.CreateOrderAsync(userId, model);
                TempData["SuccessMessage"] = "Your order has been placed successfully!";
                return RedirectToAction(nameof(OrderHistory));
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index), "Cart");
            }
        }

        [HttpGet]
        public async Task<IActionResult> OrderHistory()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await this.orderService.GetUserOrderAsync(userId);

            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetails(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderDetails = await this.orderService.GetOrderDetailAsync(id, userId);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }
    }
}
