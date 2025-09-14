using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static EcommerceApp.Common.EntityValidationConstants.Category;

namespace EcommerceApp.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [MinLength(CategoryNameMinLength)]
        [Comment("Name of the category.")]
        public string Name { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
