using EcommerceApp.Web.ViewModels.Review;

namespace EcommerceApp.Web.ViewModels.Product
{
    public class ProductIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
        public DateTime CreatedOn { get; set; }
        public string UserId { get; set; } = string.Empty;
        public List<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();
    }
}
