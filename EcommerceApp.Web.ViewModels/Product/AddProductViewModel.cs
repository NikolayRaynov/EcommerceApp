using EcommerceApp.Web.ViewModels.Category;
using Microsoft.AspNetCore.Http;
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

        [MaxLength(ImageMaxLength)]
        public string Image { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }
        public IEnumerable<IFormFile> Images { get; set; } = new List<IFormFile>();
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
