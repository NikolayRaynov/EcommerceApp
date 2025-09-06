using EcommerceApp.Common.Enums;
using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repository;

        public OrderService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateOrderAsync(string userId, OrderCheckoutViewModel model)
        {
            var userCart = this.repository
                .All<Cart>()
                .Include(cp => cp.CartProducts)
                .ThenInclude(p => p.Product)
                .FirstOrDefault(c => c.UserId == userId);

            if (userCart == null || !userCart.CartProducts.Any())
            {
                throw new InvalidOperationException("Cannot create an order from an empty cart.");
            }

            decimal totalAmount = userCart.CartProducts.Sum(cp => cp.Product.Price * cp.Quantity);

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                ShippingAddress = model.ShippingAddress,
                Status = OrderStatus.Pending,
                TotalAmount = totalAmount
            };

            await this.repository.AddAsync(order);
            await this.repository.SaveChangesAsync();

            foreach (var cartProduct in userCart.CartProducts)
            {
                var orderProduct = new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = cartProduct.ProductId,
                    Quantity = cartProduct.Quantity,
                    PriceAtTimeOfPurchase = cartProduct.Product.Price
                };

                await this.repository.AddAsync(orderProduct);
            }

            await this.repository.SaveChangesAsync();

            this.repository.DeleteRange(userCart.CartProducts);
            await this.repository.SaveChangesAsync();
        }

        public async Task<OrderDetailViewModel> GetOrderDetailAsync(int orderId, string userId)
        {
            var order = await this.repository
                .AllReadonly<Order>()
                .Include(op => op.OrderProducts)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId && o.UserId == userId);

            if (order == null)
            {
                return null;
            }

            var viewModel = new OrderDetailViewModel
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                ShippingAddress = order.ShippingAddress,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                OrderItems = order.OrderProducts
                    .Select(op => new OrderItemViewModel
                    {
                        ProductName = op.Product.Name,
                        Image = op.Product.Image,
                        Description = op.Product.Description,
                        Quantity = op.Quantity,
                        Price = op.PriceAtTimeOfPurchase,
                        LineTotal = op.PriceAtTimeOfPurchase * op.Quantity
                    })
                    .ToList()
            };

            return viewModel;
        }

        public async Task<decimal> GetTotalAmountAsync(string userId)
        {
            var userCart = await this.repository
                .AllReadonly<Cart>()
                .Include(cp => cp.CartProducts)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(uc => uc.UserId == userId);

            if (userCart == null || !userCart.CartProducts.Any())
            {
                return 0;
            }

            return userCart.CartProducts.Sum(p => p.Product.Price * p.Quantity);
        }

        public async Task<ICollection<OrderHistoryViewModel>> GetUserOrderAsync(string userId)
        {
            var orders = await this.repository
                .AllReadonly<Order>()
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new OrderHistoryViewModel
                {
                    OrderId = o.Id,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status
                })
                .ToListAsync();

            return orders;
        }
    }
}
