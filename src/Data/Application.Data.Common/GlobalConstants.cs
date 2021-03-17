namespace Application.Data.Common
{
    public static class GlobalConstants
    {
        public static string[] AllowedImageExtensions => new[] { "jpg", "jpeg", "png", "gif", "tiff", "psd", "pdf", "eps" };

        public static string DefaultProfileImageName => "DefaultProfileImage.png";

        /// <summary>
        /// use String.Format to put folder directory.
        /// </summary>
        public static string GetsDefaultProfileImagePath => "/{0}/DefaultProfileImage.png";

        /// <summary>
        /// set folder directory, image Id and image extension.
        /// </summary>
        public static string GetsLocalImagePath => "{0}{1}.{2}";

        public static string DefaultCoverImageName => "DefaultCoverImage.jpg";

        /// <summary>
        /// use String.Format to put folder directory.
        /// </summary>
        public static string GetsDefaultCoverImagePath => "/{0}/DefaultCoverImage.jpg";
    }
}
