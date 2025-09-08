using EcommerceApp.Web.ViewModels.Admin.UserManagement;

namespace EcommerceApp.Services.Data.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
		Task<bool> UserExistsByIdAsync(string userId);
		Task<bool> AssignUserToRoleAsync(string userId, string roleName);
		Task<bool> RemoveUserRoleAsync(string userId, string roleName);
		Task DeleteUserAsync(string userId);
		Task<int> GetTotalUsersCountAsync();
    }
}