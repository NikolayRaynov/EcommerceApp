using EcommerceApp.Web.ViewModels.Order;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface IStripeService
    {
        Task<string> CreateCheckoutSessionUrlAsync(OrderCheckoutViewModel checkoutViewModel);
    }
}
