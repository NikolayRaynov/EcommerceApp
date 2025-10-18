using EcommerceApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace EcommerceApp.Services.Data
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment environment;

        public FileService(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        public string SanitizeFolderName(string folderName)
        {
            char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
            char[] invalidPathChars = Path.GetInvalidPathChars();

            string sanitized = new string(folderName
                .Where(c => !invalidFileNameChars.Contains(c) && !invalidPathChars.Contains(c))
                .ToArray());

            sanitized = Regex.Replace(sanitized, @"[^a-zA-Z0-9_-]", "");

            return sanitized;
        }

        public async Task<string> SaveProfilePictureAsync(IFormFile file, string userId)
        {
            string uploadsFolder = Path.Combine(environment.WebRootPath, "images", "profilePictures");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileExtension = Path.GetExtension(file.FileName);
            string uniqueFileName = $"user-{userId}{fileExtension}";
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"/images/profilePictures/{uniqueFileName}";
        }
    }
}
