namespace EcommerceApp.Web.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;
    using static EcommerceApp.Common.EntityValidationConstants.Review;
    public class DeleteReviewViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }

        [MaxLength(CommentMaxLength)]
        public string? Comment { get; set; }
    }
}
