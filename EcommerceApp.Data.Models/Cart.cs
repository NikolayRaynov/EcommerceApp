using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.Data.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Identifier of the product in the cart.")]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;

        [Required]
        [Comment("Quantity of the product in the cart.")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Identifier of the user who owns the cart.")]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;
    }
}
