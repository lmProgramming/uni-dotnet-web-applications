namespace EntityFramework.Utilities
{
    public static class ImageHelper
    {
        public static string GetImagePath(string? imagePath)
        {
            return string.IsNullOrEmpty(imagePath) ? "/images/default.png" : imagePath;
        }
    }
}
