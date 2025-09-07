using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Web.ViewModels.Order
{
    public class OrderCheckoutViewModel
    {
        [Required]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; } = null!;
        //public string PaymentToken { get; set; } = null!;
        public decimal TotalAmount { get; set; }
    }
}
