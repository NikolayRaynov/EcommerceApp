using Stripe.Checkout;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface IStripeService
    {
        string CreateSessionAsync(
            List<SessionLineItemOptions> lineItems,
            string secretKey,
            string successUrl,
            string cancelUrl);
    }
}