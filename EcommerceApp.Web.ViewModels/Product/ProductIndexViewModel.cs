namespace EcommerceApp.Web.ViewModels.Product
{
    public class ProductIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}
