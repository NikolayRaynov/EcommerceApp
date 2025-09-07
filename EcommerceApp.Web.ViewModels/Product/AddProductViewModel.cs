using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static EcommerceApp.Common.EntityValidationConstants.Product;

namespace EcommerceApp.Web.ViewModels.Product
{
    public class AddProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        [MinLength(ProductNameMinLength)]
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

        [Required]
        [Comment("Date and time the product was added.")]
        public DateTime CreatedOn { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
