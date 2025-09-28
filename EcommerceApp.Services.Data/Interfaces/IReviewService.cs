using EcommerceApp.Web.ViewModels.Review;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewViewModel>> GetReviewsByProductIdAsync(int productId);
        Task<ReviewViewModel?> GetReviewByIdAsync(int reviewId);
        Task AddReviewAsync(AddReviewViewModel model, string userId);
        Task UpdateReviewAsync(EditReviewViewModel model, string userId);
        Task DeleteReviewAsync(DeleteReviewViewModel model, string userId);
    }
}
