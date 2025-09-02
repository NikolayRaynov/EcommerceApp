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
            var userCart = await GetCartAsync(userId);

            var cartItems = await repository
                .All<CartProduct>()
                .Where(cp => cp.CartId == userCart.Id)
                .Include(cp => cp.Product)
                .Select(c => new CartItemViewModel
                {
                    Id = c.ProductId,
                    ProductName = c.Product.Name,
                    ImageUrl = c.Product.Image,
                    Quantity = c.Quantity,
                    Price = c.Product.Price
                })
                .ToListAsync();

            var model = new CartIndexViewModel
            {
                CartItems = cartItems,
                ShippingCost = DefaultShippingCost
            };

            return model;
        }

        public async Task AddProductToCartAsync(int productId, string userId)
        {
            var userCart = await GetCartAsync(userId);

            var existingCartItem = await repository
                .All<CartProduct>()
                .FirstOrDefaultAsync(cp => cp.CartId == userCart.Id && cp.ProductId == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                var cartProduct = new CartProduct
                {
                    CartId = userCart.Id,
                    ProductId = productId,
                    Quantity = 1
                };

                await repository.AddAsync(cartProduct);
            }

            await repository.SaveChangesAsync();
        }

        public async Task IncreaseProductQuantityAsync(int productId, string userId)
        {
            var userCart = await GetCartAsync(userId);

            var cartProduct = await repository.All<CartProduct>()
                .FirstOrDefaultAsync(cp => cp.CartId == userCart.Id && cp.ProductId == productId);

            if (cartProduct != null)
            {
                cartProduct.Quantity++;
                await repository.SaveChangesAsync();
            }
        }

        public async Task DecreaseProductQuantityAsync(int productId, string userId)
        {
            var userCart = await GetCartAsync(userId);

            var cartProduct = await repository.All<CartProduct>()
                .FirstOrDefaultAsync(cp => cp.CartId == userCart.Id && cp.ProductId == productId);

            if (cartProduct != null)
            {
                cartProduct.Quantity--;

                if (cartProduct.Quantity <= 0)
                {
                    repository.Delete(cartProduct);
                }

                await repository.SaveChangesAsync();
            }
        }

        public async Task RemoveProductFromCartAsync(int productId, string userId)
        {
            var userCart = await GetCartAsync(userId);

            var cartItem = await repository
                .All<CartProduct>()
                .FirstOrDefaultAsync(cp => cp.CartId == userCart.Id && cp.ProductId == productId);

            if (cartItem == null)
            {
                throw new InvalidOperationException("This product is not in your cart.");
            }

            repository.Delete(cartItem);
            await repository.SaveChangesAsync();
        }

        private async Task<Cart> GetCartAsync(string userId)
        {
            var userCart = await repository.All<Cart>()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (userCart == null)
            {
                userCart = new Cart
                {
                    UserId = userId
                };
                await repository.AddAsync(userCart);
                await repository.SaveChangesAsync();
            }

            return userCart;
        }
    }
}