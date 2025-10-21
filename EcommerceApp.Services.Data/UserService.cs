using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Admin.UserManagement;

namespace EcommerceApp.Services.Data
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IRepository repository;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IRepository repository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.repository = repository;
        }

        public async Task<int> GetTotalUsersCountAsync()
        {
            return await this.repository.AllReadonly<ApplicationUser>().CountAsync();
        }

        public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
        {
            IEnumerable<ApplicationUser> allUsers = await this.userManager.Users.ToArrayAsync();
            ICollection<AllUsersViewModel> allUsersViewModel = new List<AllUsersViewModel>();

            foreach (ApplicationUser user in allUsers)
            {
                IEnumerable<string> roles = await this.userManager.GetRolesAsync(user);

                allUsersViewModel.Add(new AllUsersViewModel()
                {
                    Id = user.Id.ToString(),
                    Username = user.UserName,
                    Email = user.Email,
                    Roles = roles
                });
            }

            return allUsersViewModel;
        }

        public async Task<bool> UserExistsByIdAsync(string userId)
        {
            ApplicationUser? user = await this.userManager.FindByIdAsync(userId);
            return user != null;
        }

        public async Task<bool> AssignUserToRoleAsync(string userId, string roleName)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }

            ApplicationUser? user = await userManager.FindByIdAsync(userId);
            bool roleExists = await this.roleManager.RoleExistsAsync(roleName);

            if (user == null || !roleExists)
            {
                return false;
            }

            bool alreadyInRole = await this.userManager.IsInRoleAsync(user, roleName);
            if (!alreadyInRole)
            {
                IdentityResult? result = await this.userManager.AddToRoleAsync(user, roleName);

                if (!result.Succeeded)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> RemoveUserRoleAsync(string userId, string roleName)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }

            ApplicationUser? user = await userManager.FindByIdAsync(userId);
            bool roleExists = await this.roleManager.RoleExistsAsync(roleName);

            if (user == null || !roleExists)
            {
                return false;
            }

            bool alreadyInRole = await this.userManager.IsInRoleAsync(user, roleName);
            if (alreadyInRole)
            {
                IdentityResult? result = await this.userManager.RemoveFromRoleAsync(user, roleName);

                if (!result.Succeeded)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task DeleteUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
            }

            ApplicationUser? user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("The user was not found.");
            }

            try
            {
                var userCart = await this.repository.All<Cart>()
                    .Include(c => c.CartProducts)
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (userCart != null)
                {
                    this.repository.DeleteRange(userCart.CartProducts);
                    this.repository.Delete(userCart);
                }

                var userOrders = await this.repository.All<Order>()
                    .Include(o => o.OrderProducts)
                    .Where(o => o.UserId == userId)
                    .ToListAsync();

                foreach (var order in userOrders)
                {
                    this.repository.DeleteRange(order.OrderProducts);
                    this.repository.Delete(order);
                }

                await repository.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException($"Database error during user cleanup: {dbEx.Message}", dbEx);
            }

            var result = await this.userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Failed to delete user Identity: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}