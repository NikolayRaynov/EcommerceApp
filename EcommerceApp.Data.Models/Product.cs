using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static EcommerceApp.Common.EntityValidationConstants.Product;

namespace EcommerceApp.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        [Comment("Name of the product")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [Comment("Description of the product")]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ImageMaxLength)]
        [Comment("Image URL for the product")]
        public string Image { get; set; } = string.Empty;
    }
}
