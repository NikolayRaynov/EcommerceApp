using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("The selling price of the product")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ImageMaxLength)]
        [Comment("Image URL for the product")]
        public string Image { get; set; } = string.Empty;

        [Required]
        [Comment("Date and time the product was added.")]
        public DateTime CreatedOn { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
