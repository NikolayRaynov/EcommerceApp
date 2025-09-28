using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Review;
using Ganss.Xss;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Services.Data
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository repository;
        private readonly IHtmlSanitizer htmlSanitizer;
        private readonly UserManager<ApplicationUser> userManager;

        public ReviewService(IRepository repository, IHtmlSanitizer htmlSanitizer, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.htmlSanitizer = htmlSanitizer;
            this.userManager = userManager;
        }

        public async Task AddReviewAsync(AddReviewViewModel model, string userId)
        {
            var IsProductExist = await repository
                .AllReadonly<Product>()
                .AnyAsync(p => p.Id == model.ProductId);

            if (!IsProductExist)
            {
                throw new InvalidOperationException("The product does not exist.");
            }

            var IsUserExist = await userManager
                .FindByIdAsync(userId) != null;

            if (!IsUserExist)
            {
                throw new InvalidOperationException("The user does not exist.");
            }

            var review = new Review
            {
                ProductId = model.ProductId,
                Rating = model.Rating,
                Comment = htmlSanitizer.Sanitize(model.Comment),
                CreatedAt = DateTime.UtcNow,
                UserId = userId
            };

            await repository.AddAsync(review);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(DeleteReviewViewModel model, string userId)
        {
            var review = await repository
                .All<Review>()
                .FirstOrDefaultAsync(r => r.Id == model.Id);

            if (review == null)
            {
                throw new InvalidOperationException("Review is not found.");
            }

            bool IsHasRights = review.UserId == userId || await IsUserAdmin(userId);

            if (IsHasRights)
            {
                repository.Delete(review);
                await repository.SaveChangesAsync();
            }
            else
            {
                throw new UnauthorizedAccessException("You do not have permission to delete this review.");
            }
        }

        public async Task<ReviewViewModel?> GetReviewByIdAsync(int reviewId)
        {
            var review = await repository
                .AllReadonly<Review>()
                .Include(r => r.User)
                .Include(r => r.Product)
                .Where(r => r.Id == reviewId)
                .Select(r => new ReviewViewModel
                {
                    Id = r.Id,
                    ProductId = r.ProductId,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    CreatedAt = r.CreatedAt,
                    User = r.User.UserName
                })
                .FirstOrDefaultAsync();

            if (review == null)
            {
                return null;
            }

            return review;
        }

        public async Task<IEnumerable<ReviewViewModel>> GetReviewsByProductIdAsync(int productId)
        {
            var reviews = await repository
                .AllReadonly<Review>()
                .Include(r => r.User)
                .Include(r => r.Product)
                .Where(r => r.ProductId == productId)
                .Select(r => new ReviewViewModel
                {
                    Id = r.Id,
                    ProductId = r.ProductId,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    CreatedAt = r.CreatedAt,
                    User = r.User.UserName
                })
                .ToListAsync();

            return reviews;
        }

        public async Task UpdateReviewAsync(EditReviewViewModel model, string userId)
        {
            var review = repository
                .All<Review>()
                .FirstOrDefault(r => r.Id == model.Id);

            if (review == null)
            {
                throw new InvalidOperationException("Review is not found.");
            }

            bool IsHasRights = review.UserId == userId || await IsUserAdmin(userId);

            if (IsHasRights)
            {
                review.Rating = model.Rating;
                review.Comment = htmlSanitizer.Sanitize(model.Comment);

                await repository.SaveChangesAsync();
            }
            else
            {
                throw new UnauthorizedAccessException("You do not have permission to edit this review.");
            }
        }

        private async Task<bool> IsUserAdmin(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }
            return await userManager.IsInRoleAsync(user, AdminRoleName);
        }
    }
}
