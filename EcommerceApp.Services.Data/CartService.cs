using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Cart;
using Microsoft.EntityFrameworkCore;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Services.Data
{
    public class CartService : ICartService
    {
        private readonly IRepository repository;
        private readonly IProductService productService;

        public CartService(IRepository repository, IProductService productService)
        {
            this.repository = repository;
            this.productService = productService;
        }

        public async Task<CartIndexViewModel> GetUserCartAsync(string userId)
        {
            //var cartItems = await repository
            //    .All<Cart>()
            //    .Where(c => c.UserId == userId)
            //    .Include(c => c.Product)
            //    .Select(c => new CartItemViewModel
            //    {
            //        Id = c.Id,
            //        ProductName = c.Product.Name,
            //        ImageUrl = c.Product.Image,
            //        Quantity = c.Quantity,
            //        Price = c.Product.Price
            //    })
            //    .ToListAsync();

            var model = new CartIndexViewModel
            {
                //CartItems = cartItems,
                ShippingCost = DefaultShippingCost
            };

            return model;
        }

        public async Task AddProductToCartAsync(int productId, string userId)
        {
            //var existingCartItem = await repository
            //    .All<Cart>()
            //    .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

            //if (existingCartItem != null)
            //{
            //    existingCartItem.Quantity++;
            //}
            //else
            //{
            //    var cartItem = new Cart
            //    {
            //        UserId = userId,
            //        ProductId = productId,
            //        Quantity = 1
            //    };

            //    await repository.AddAsync(cartItem);
            //}
            
            //await repository.SaveChangesAsync();
        }

        public async Task IncreaseProductQuantityAsync(int cartItemId)
        {
            //var cartItem = await repository.All<Cart>().FirstOrDefaultAsync(ci => ci.Id == cartItemId);
            //if (cartItem != null)
            //{
            //    cartItem.Quantity++;
            //    await repository.SaveChangesAsync();
            //}
        }

        public async Task DecreaseProductQuantityAsync(int cartItemId)
        {
            //var cartItem = await repository.All<Cart>().FirstOrDefaultAsync(ci => ci.Id == cartItemId);
            //if (cartItem != null)
            //{
            //    cartItem.Quantity--;
            //    if (cartItem.Quantity <= 0)
            //    {
            //        await repository.DeleteAsync<Cart>(cartItem);
            //    }
            //    await repository.SaveChangesAsync();
            //}
        }

        public async Task RemoveProductFromCartAsync(int cartItemId)
        {
            var cartItem = await repository
                .All<Cart>()
                .FirstOrDefaultAsync(ci => ci.Id == cartItemId);

            if (cartItem == null)
            {
                throw new InvalidOperationException("This product is not in your cart.");
            }

            repository.Delete(cartItem);
            await repository.SaveChangesAsync();
        }
    }
}