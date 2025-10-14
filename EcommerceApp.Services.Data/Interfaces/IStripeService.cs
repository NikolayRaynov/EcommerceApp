using Stripe.Checkout;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface IStripeService
    {
        Task<string> CreateSessionAsync(
            List<SessionLineItemOptions> lineItems,
            string secretKey,
            string successUrl,
            string cancelUrl);
    }
}