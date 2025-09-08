using EcommerceApp.Common.Enums;

namespace EcommerceApp.Web.ViewModels.Order
{
    public class OrderHistoryViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public string UserId { get; set; } = null!;
    }
}
