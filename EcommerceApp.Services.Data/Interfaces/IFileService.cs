using Microsoft.AspNetCore.Http;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface IFileService
    {
        string SanitizeFolderName(string folderName);
        Task<string> SaveProfilePictureAsync(IFormFile file, string userId);
    }
}
