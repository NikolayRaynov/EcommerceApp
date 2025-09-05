namespace EcommerceApp.Web.ViewModels.Order
{
    public class OrderItemViewModel
    {
        public string ProductName { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal LineTotal { get; set; }
    }
}
