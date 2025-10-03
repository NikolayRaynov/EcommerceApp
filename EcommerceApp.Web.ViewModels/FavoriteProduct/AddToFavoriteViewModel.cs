using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Web.ViewModels.FavoriteProduct
{
    using static EcommerceApp.Common.EntityValidationConstants.Product;
    using static EcommerceApp.Common.EntityValidationConstants.Image;
    public class AddToFavoriteViewModel
    {
        public int ProductId { get; set; }

        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), ProductPriceMinValue, ProductPriceMaxValue)]
        public decimal ProductPrice { get; set; }

        [Required]
        [MinLength(ProductDescriptionMinLength)]
        [MaxLength(ProductDescriptionMaxLength)]
        public string ProductDescription { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public List<string> ProductImageUrls { get; set; } = new List<string>();
    }
}
