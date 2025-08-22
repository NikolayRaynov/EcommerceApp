using EcommerceApp.Web.ViewModels.Product;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductIndexViewModel>> GetAllProductsAsync(int page = DefaultPageNumber, 
            int pageSize = DefaultPageSize, string? searchTerm = null);
        Task<int> AddProductAsync(AddProductViewModel model);
        Task<EditProductViewModel?> GetProductForEditAsync(int productId);
        Task<bool> UpdateProductAsync(EditProductViewModel model);
        Task<DeleteProductViewModel?> GetProductForDeleteAsync(int productId);
        Task<bool> DeleteProductAsync(int productId);
        Task<int> GetProductCountAsync(string? searchTerm = null);
        Task<ProductIndexViewModel?> GetProductByIdAsync(int productId);
    }
}
