using System.ComponentModel.DataAnnotations;
using static EcommerceApp.Common.EntityValidationConstants.Order;

namespace EcommerceApp.Web.ViewModels.Order
{
    public class OrderCheckoutViewModel
    {
        public string? OrderId { get; set; }

        [Required(ErrorMessage = "Shipping address is required.")]
        [StringLength(OrderAddressMaxLength, MinimumLength = OrderAddressMinLength, 
            ErrorMessage = "Address must be between 10 and 200 characters.")]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; } = null!;

        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        public string CurrencySymbol { get; set; } = "€";
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public int TotalItems => OrderItems.Sum(i => i.Quantity);

        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
    }
}