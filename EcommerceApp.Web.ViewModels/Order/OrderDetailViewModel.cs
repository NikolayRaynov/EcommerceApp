using EcommerceApp.Common.Enums;

namespace EcommerceApp.Web.ViewModels.Order
{
    public class OrderDetailViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; } = null!;
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
    }
}
