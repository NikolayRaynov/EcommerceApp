using System.ComponentModel.DataAnnotations;
using static EcommerceApp.Common.EntityValidationConstants.Cart;
using static EcommerceApp.Common.EntityValidationConstants.Product;

namespace EcommerceApp.Web.ViewModels.Cart
{
    public class CartAddViewModel
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(CartItemMinQuantity, CartItemMaxQuantity)]
        public int Quantity { get; set; }

        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        [MaxLength(ImageMaxLength)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
