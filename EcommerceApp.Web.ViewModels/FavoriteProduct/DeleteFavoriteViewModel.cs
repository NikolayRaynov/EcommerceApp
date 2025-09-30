namespace EcommerceApp.Web.ViewModels.FavoritePlace
{
    using System.ComponentModel.DataAnnotations;
    using static EcommerceApp.Common.EntityValidationConstants.Product;
    using static EcommerceApp.Common.EntityValidationConstants.Image;
    public class DeleteFavoriteViewModel
    {
        public int DestinationId { get; set; }

        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range(typeof(int), ProductPriceMinValue, ProductPriceMaxValue)]
        public int ProductPrice { get; set; }

        [Required]
        [MinLength(ProductDescriptionMinLength)]
        [MaxLength(ProductDescriptionMaxLength)]
        public string ProductDescription { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public List<string> ProductImageUrls { get; set; } = new List<string>();
    }
}
