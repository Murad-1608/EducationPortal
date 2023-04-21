using Microsoft.AspNetCore.Http;

namespace Business.Helper
{
    public static class SystemIOOperations
    {
        public static string AddPhoto(IFormFile file, string folderName)
        {
            if (file == null)
            {
                return null;
            }
            else
            {
                var extension = Path.GetExtension(file.FileName);
                var newImageName = file.FileName + Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/{folderName}/" + newImageName);

                using (var stream = new FileStream(location, FileMode.Create))
                {
                    file.CopyTo(stream);
                    return newImageName;
                }
            }

        }

        public static void DeletePhoto(string Category, string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
            }
            else
            {
                string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/{Category}/" + Name);

                if (System.IO.File.Exists(FolderPath))
                {
                    System.IO.File.Delete(FolderPath);
                }
            }
        }
        public static async Task<string> DownloadFile(string Category, string Name)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/{Category}", Name);
            var memory = new MemoryStream();

            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }

            }
            catch (Exception)
            {
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);

            return fileName;
        }

    }
}
