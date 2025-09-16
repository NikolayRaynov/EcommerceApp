using EcommerceApp.Services.Data.Interfaces;
using System.Text.RegularExpressions;

namespace EcommerceApp.Services.Data
{
    public class FileService : IFileService
    {
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
    }
}
