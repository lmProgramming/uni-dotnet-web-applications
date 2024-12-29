namespace EntityFramework.Utilities
{
    public static class ImageHelper
    {
        public static string GetImagePath(string? imagePath)
        {
            return "/images/" + (string.IsNullOrEmpty(imagePath) ? "default.png" : imagePath);
        }
    }
}
