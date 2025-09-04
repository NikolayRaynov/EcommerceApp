using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EcommerceApp.Common.EntityValidationConstants.Product;

namespace EcommerceApp.Data.Models
{
    public class CartProduct
    {
        [Required]
        [Comment("The Id of the cart to which the product belongs.")]
        public int CartId { get; set; }
        [ForeignKey(nameof(CartId))]
        public virtual Cart Cart { get; set; } = null!;

        [Required]
        [Comment("The Id of the product in the cart.")]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;

        [Required]
        [Range(MinQuantity, MaxQuantity)]
        [Comment("Quantity of the product in the cart.")]
        public int Quantity { get; set; }
    }
}
