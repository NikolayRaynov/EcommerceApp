using System.ComponentModel.DataAnnotations;
using static EcommerceApp.Common.EntityValidationConstants.Category;

namespace EcommerceApp.Web.ViewModels.Category
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the category is required.")]
        [StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength,
            ErrorMessage = "The name must be between {2} and {1} characters long.")]
        public string Name { get; set; } = string.Empty;
    }
}
