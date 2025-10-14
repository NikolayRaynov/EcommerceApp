using EcommerceApp.Services.Data.Interfaces;
using Stripe;
using Stripe.Checkout;

namespace EcommerceApp.Services.Data
{
    public class StripeService : IStripeService
    {
        public string CreateSessionAsync(
            List<SessionLineItemOptions> lineItems,
            string secretKey,
            string successUrl,
            string cancelUrl)
        {
            StripeConfiguration.ApiKey = secretKey;

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",

                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return session.Url;
        }
    }
}
