using EcommerceApp.Common.Enums;
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

            try
            {
                var model = await this.orderService.GetCheckoutDetailsAsync(userId);

                if (!model.OrderItems.Any())
                {
                    TempData["ErrorMessage"] = "Your cart is empty and cannot be checked out.";
                    return RedirectToAction(nameof(Index), "Cart");
                }

                return View(model);
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index), "Cart");
            }
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
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
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

            var checkoutDetails = await this.orderService.GetCheckoutDetailsAsync(userId);
            TempData["ShippingAddress"] = model.ShippingAddress;

            string successUrl = this.Url.Action(
                nameof(Success),
                "Order",
                null,
                protocol: Request.Scheme
            )!;

            string cancelUrl = this.Url.Action(
                nameof(Cancel),
                "Order",
                null,
                protocol: Request.Scheme
            )!;

            var lineItems = new List<SessionLineItemOptions>();

            foreach (var item in checkoutDetails.OrderItems)
            {
                lineItems.Add(new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmountDecimal = item.Price * 100,
                        Currency = "eur",
                        ProductData = new SessionLineItemPriceDataProductDataOptions { Name = item.ProductName }
                    },
                    Quantity = item.Quantity
                });
            }

            lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = checkoutDetails.ShippingCost * 100,
                    Currency = "eur",
                    ProductData = new SessionLineItemPriceDataProductDataOptions { Name = "Shipping Fee" }
                },
                Quantity = 1
            });

            string sessionUrl = this.stripeService.CreateSessionAsync(
                lineItems,
                this.stripeSettings.SecretKey,
                successUrl,                   
                cancelUrl                     
            );

            return Redirect(sessionUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Success()
        {
            string? shippingAddress = TempData["ShippingAddress"] as string;

            if (string.IsNullOrEmpty(shippingAddress))
            {
                return RedirectToAction(nameof(Checkout));
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int orderId = 0;

            try
            {
                var orderCheckout = new OrderCheckoutViewModel { ShippingAddress = shippingAddress };
                orderId = await this.orderService.CreateOrderAsync(userId, orderCheckout);

                await this.orderService.UpdateUserOrderStatusAsync(orderId, OrderStatus.Processing);

                return View();
            }
            catch (InvalidOperationException ex)
            {
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cancel(int orderId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.orderService.UpdateUserOrderStatusAsync(orderId, OrderStatus.Cancelled);

            return View();
        }
    }
}