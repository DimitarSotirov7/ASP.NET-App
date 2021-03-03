namespace Application.Data.Common
{
    public static class GlobalConstants
    {
        public static string[] AllowedImageExtensions => new[] { "jpg", "jpeg", "png", "gif", "tiff", "psd", "pdf", "eps" };

        public static string DefaultProfileImageName => "DefaultProfileImage.png";

        public static string DefaultCoverImageName => "DefaultCoverImage.jpg";
    }
}
