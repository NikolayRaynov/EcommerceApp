namespace EcommerceApp.Web.ViewModels.Product
{
    public class ProductPageViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public List<ProductIndexViewModel> Products { get; set; }

        public ProductPageViewModel()
        {
            Products = new List<ProductIndexViewModel>();
        }
    }
}
