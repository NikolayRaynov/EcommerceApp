using EcommerceApp.Web.ViewModels.Category;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllAsync();
        Task<CategoryViewModel?> GetByIdAsync(int id);
        Task<EditCategoryViewModel?> GetCategoryForAsync(int id);
        Task AddAsync(AddCategoryViewModel model, string webRootPath);
        Task UpdateAsync(int id, EditCategoryViewModel model, string webRootPath);
        Task<bool> ExistsByIdAsync(int id);
        Task<string?> GetCategoryNameByIdAsync(int id);
    }
}
