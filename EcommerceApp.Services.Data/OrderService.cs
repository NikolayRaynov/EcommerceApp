using EcommerceApp.Common.Enums;
using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Order;
using EcommerceApp.Web.ViewModels.Product;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repository;
        private const decimal ShippingFee = 5.00m;
        public OrderService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task ClearUserCartAsync(string userId)
        {
            var userCart = await this.repository
                .All<Cart>()
                .Include(cp => cp.CartProducts)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (userCart != null && userCart.CartProducts.Any())
            {
                this.repository.DeleteRange(userCart.CartProducts);
                await this.repository.SaveChangesAsync();
            }

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

            decimal totalAmount = userCart.CartProducts.Sum(cp => (decimal)cp.Product.Price * cp.Quantity);

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                ShippingAddress = model.ShippingAddress,
                Status = OrderStatus.Pending,
                TotalAmount = totalAmount + ShippingFee
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

                if (cartProduct.Product.StockQuantity >= cartProduct.Quantity)
                {
                    cartProduct.Product.StockQuantity -= cartProduct.Quantity;
                }
                else
                {
                    throw new InvalidOperationException($"Insufficient stock for product {cartProduct.Product.Name}");
                }
            }

            await this.repository.SaveChangesAsync();

            await this.ClearUserCartAsync(userId);
        }

        public async Task<OrderCheckoutViewModel> GetCheckoutDetailsAsync(string userId)
        {
            var userCart = await this.repository
                .AllReadonly<Cart>()
                .Where(uc => uc.UserId == userId)
                .Include(cp => cp.CartProducts)
                .ThenInclude(p => p.Product)
                .ThenInclude(i => i.Images)
                .FirstOrDefaultAsync();

            if (userCart == null || !userCart.CartProducts.Any())
            {
                return new OrderCheckoutViewModel { TotalAmount = ShippingFee, Subtotal = 0, ShippingCost = ShippingFee };
            }

            decimal subtotal = userCart.CartProducts.Sum(cp => cp.Product.Price * cp.Quantity);

            decimal totalAmount = subtotal + ShippingFee;

            var viewModel = new OrderCheckoutViewModel
            {
                Subtotal = subtotal,
                ShippingCost = ShippingFee,
                TotalAmount = totalAmount,
                CurrencySymbol = "€",
                OrderItems = userCart.CartProducts
                    .Select(cp => new OrderItemViewModel
                    {
                        ProductName = cp.Product.Name,
                        Description = cp.Product.Description,
                        Quantity = cp.Quantity,
                        Price = cp.Product.Price,
                        LineTotal = cp.Product.Price * cp.Quantity,
                        ImageUrls = cp.Product.Images.Select(i => i.Url).ToList()
                    })
                    .ToList()
            };

            return viewModel;
        }

        public async Task<OrderDetailViewModel> GetOrderDetailAsync(int orderId, string userId)
        {
            var order = await this.repository
                .AllReadonly<Order>()
                .Include(op => op.OrderProducts)
                .ThenInclude(p => p.Product)
                .ThenInclude(i => i.Images)
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
                        ImageUrls = op.Product.Images.Select(i => i.Url).ToList(),
                        Description = op.Product.Description,
                        Quantity = op.Quantity,
                        Price = op.PriceAtTimeOfPurchase,
                        LineTotal = op.PriceAtTimeOfPurchase * op.Quantity
                    })
                    .ToList()
            };

            return viewModel;
        }

        public async Task<IEnumerable<OrderStatusCountViewModel>> GetOrderStatusDistributionAsync()
        {
            var orderStatusDistribution = await this.repository
                .AllReadonly<Order>()
                .GroupBy(o => o.Status)
                .Select(os => new OrderStatusCountViewModel
                {
                    StatusName = os.Key.ToString(),
                    Count = os.Count()
                })
                .OrderByDescending(d => d.Count)
                .ToListAsync();

            return orderStatusDistribution;
        }

        public async Task<ICollection<OrderHistoryViewModel>> GetRecentOrdersAsync(int count)
        {
            var recentOrders = await this.repository
                .AllReadonly<Order>()
                .OrderByDescending(o => o.OrderDate)
                .Take(count)
                .Select(o => new OrderHistoryViewModel
                {
                    OrderId = o.Id,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    UserId = o.UserId
                })
                .ToListAsync();

            return recentOrders;
        }

        public async Task<IEnumerable<TopSellingProductsViewModel>> GetTopSellingProductsAsync(int topSellingCount)
        {
            var topSellingProducts = await this.repository
                .AllReadonly<OrderProduct>()
                .Include(op => op.Product)
                .GroupBy(op => op.ProductId)
                .Select(tp => new TopSellingProductsViewModel
                {
                    ProductName = tp.First().Product.Name,
                    QuantitySold = tp.Sum(op => op.Quantity)
                })
                .OrderByDescending(p => p.QuantitySold)
                .Take(topSellingCount)
                .ToListAsync();

            return topSellingProducts;
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

        public async Task<int> GetTotalOrdersCountAsync()
        {
            return await this.repository.AllReadonly<Order>().CountAsync();
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await this.repository.AllReadonly<Order>().SumAsync(o => o.TotalAmount);
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

