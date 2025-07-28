namespace EcommerceApp.Web.ViewModels.Cart
{
    public class CartIndexViewModel
    {
        public decimal ShippingCost { get; set; }
        public decimal Subtotal => this.CartItems.Sum(item => item.LineTotal);
        public decimal Total => this.Subtotal + this.ShippingCost;
        public ICollection<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();
    }
}
