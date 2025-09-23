using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EcommerceApp.Common.EntityValidationConstants.Image;

namespace EcommerceApp.Data.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("URL of the image.")]
        public string Url { get; set; } = string.Empty;

        [Required]
        [MaxLength(ImageDescriptionMaxLength)]
        [Comment("Description of the image.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Identifier of the product to which the image belongs.")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;
    }
}
