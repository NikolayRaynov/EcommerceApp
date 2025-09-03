using EcommerceApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceApp.ViewComponents
{
    public class CartItemCountViewComponent : ViewComponent
    {
        private readonly ICartService cartService;

        public CartItemCountViewComponent(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Проверете дали потребителят е автентикиран
            if (!User.Identity.IsAuthenticated)
            {
                return View(0);
            }

            var userId = ((ClaimsPrincipal)User).FindFirstValue(ClaimTypes.NameIdentifier);

            // Допълнителна проверка за сигурност
            if (string.IsNullOrEmpty(userId))
            {
                return View(0);
            }

            var itemCount = await this.cartService.GetCartItemCountAsync(userId);
            return View(itemCount);
        }
    }
}
