using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EcommerceApp.Common.EntityValidationConstants.Review;

namespace EcommerceApp.Data.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Comment("Rating given to the product.")]
        public int Rating { get; set; }

        [MaxLength(CommentMaxLength)]
        [Comment("Comment from the user about the product.")]
        public string? Comment { get; set; }

        [Required]
        [Comment("Date when the review was created.")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Comment("Identifier of the user who wrote the review.")]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Identifier of the product for which the review is written.")]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;
    }
}
