using EcommerceApp.Data.Configuration.Settings;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe.Checkout;
using System.Security.Claims;

namespace EcommerceApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private readonly IStripeService stripeService;
        private readonly StripeSettings stripeSettings;
        public OrderController(IOrderService orderService, ICartService cartService, 
            IStripeService stripeService, IOptions<StripeSettings> stripeSettings)
        {
            this.orderService = orderService;
            this.cartService = cartService;
            this.stripeService = stripeService;
            this.stripeSettings = stripeSettings.Value;
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

            var model = new OrderCheckoutViewModel
            {
                TotalAmount = await this.orderService.GetTotalAmountAsync(userId)
            };

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

        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession(OrderCheckoutViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await this.cartService.GetUserCartAsync(userId);

            if (cart == null || !cart.CartItems.Any())
            {
                TempData["ErrorMessage"] = "Your cart is empty.";
                return RedirectToAction(nameof(Index), "Cart");
            }

            var lineItems = cart.CartItems.Select(item => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = (decimal)item.Price * 100,
                    Currency = "eur",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = item.ProductName
                    }
                },
                Quantity = item.Quantity
            }).ToList();

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = stripeSettings.SuccessUrl,
                CancelUrl = stripeSettings.CancelUrl
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return Redirect(session.Url);
        }

        [HttpGet]
        public async Task<IActionResult> Success(string session_id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = new OrderCheckoutViewModel
            {
                TotalAmount = await this.orderService.GetTotalAmountAsync(userId),
                CurrencySymbol = "€"
            };

            await this.orderService.CreateOrderAsync(userId, model);
            TempData["SuccessMessage"] = "Your payment was successful! Order created.";

            return View(nameof(Success));
        }

        [HttpGet]
        public IActionResult Cancel()
        {
            TempData["ErrorMessage"] = "Payment was cancelled.";
            return RedirectToAction(nameof(Checkout));
        }
    }
}
