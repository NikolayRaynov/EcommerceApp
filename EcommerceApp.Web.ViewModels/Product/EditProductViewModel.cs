using System.ComponentModel.DataAnnotations;
using static EcommerceApp.Common.EntityValidationConstants.Product;

namespace EcommerceApp.Web.ViewModels.Product
{
    public class EditProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        [MinLength(ProductNameMinLenghth)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [MinLength(ProductDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ImageMaxLength)]
        public string Image { get; set; } = string.Empty;
    }
}
