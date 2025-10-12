namespace EcommerceApp.Web.ViewModels.Cart
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal LineTotal => this.Quantity * this.Price;
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}
