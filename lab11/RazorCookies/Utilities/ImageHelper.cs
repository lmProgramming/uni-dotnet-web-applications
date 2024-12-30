using RazorCookies.Models;

namespace RazorCookies.Utilities
{
    public static class ImageHelper
    {
        public static string GetImagePath(string? imagePath)
        {
            return "/images/" + (string.IsNullOrEmpty(imagePath) ? "default.png" : imagePath);
        }

        public static void SaveArticleImage(Article article, IFormFile? imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                article.ImageName = fileName;
            }
        }
    }
}
