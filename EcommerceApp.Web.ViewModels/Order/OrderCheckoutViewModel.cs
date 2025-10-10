using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Web.ViewModels.Order
{
    public class OrderCheckoutViewModel
    {
        public string OrderId { get; set; } = null!;

        [Display(Name = "Name")]
        public string ProductName { get; set; } = null!;

        [Display(Name = "Description")]
        public string ProductDescription { get; set; } = null!;

        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; } = null!;

        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        public string CurrencySymbol { get; set; } = "€";
        public List<string> ProductImageUrls { get; set; } = new List<string>();
    }
}