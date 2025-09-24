using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.Data.Models
{
    public class FavoriteProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Identifier of the user who marked the product as favorite.")]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
