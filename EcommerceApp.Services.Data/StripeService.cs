using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Order;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;

namespace EcommerceApp.Services.Data
{
    public class StripeService : IStripeService
    {
        private readonly IConfiguration _configuration;

        public StripeService(IConfiguration configuration)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        }
        public async Task<string> CreateCheckoutSessionUrlAsync(OrderCheckoutViewModel checkoutViewModel)
        {
            long amountInCents = (long)(checkoutViewModel.TotalAmount * 100);

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = checkoutViewModel.CurrencySymbol,
                        UnitAmount = amountInCents,
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = $"Order {checkoutViewModel.OrderId}",
                            Description = "Payment for E-commerce order."
                        },
                    },
                    Quantity = 1,
                },
            },
                Mode = "payment",
                SuccessUrl = $"{_configuration["Stripe:SuccessUrl"]}?session_id={{CHECKOUT_SESSION_ID}}&orderId={checkoutViewModel.OrderId}",
                CancelUrl = $"{_configuration["Stripe:CancelUrl"]}?orderId={checkoutViewModel.OrderId}",
                ClientReferenceId = checkoutViewModel.OrderId
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            return session.Url;
        }
    }
}
