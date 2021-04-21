using System;

namespace Application.Data.Common
{
    public static class GlobalConstants
    {
        public static string[] AllowedImageExtensions => new[] { "jpg", "jpeg", "png", "gif", "tiff", "psd", "pdf", "eps" };

        public static string DefaultProfileImageName => "DefaultProfileImage.png";

        public static string DefaultCoverImageName => "DefaultCoverImage.jpg";

        public static string GetProfileImagePath(string imageId, string imageExtension, string imageUrl)
        {
            if (imageUrl != null)
            {
                return imageUrl;
            }

            string localPath = string.Empty;

            if (imageId == null)
            {
                localPath = $"/images/{DefaultProfileImageName}";
            }
            else
            {
                localPath = "/images/users/" + imageId + "." + imageExtension;
            }

            return localPath;
        }

        public static string GetCoverPath(string imageId, string imageExtension, string imageUrl)
        {
            if (imageUrl != null)
            {
                return imageUrl;
            }

            string localPath = string.Empty;

            if (imageId == null)
            {
                localPath = $"/images/{DefaultCoverImageName}";
            }
            else
            {
                localPath = "/images/users/" + imageId + "." + imageExtension;
            }

            return localPath;
        }

        public static string GetImagePath(string imageId, string imageExtension, string folder, string imageUrl)
        {
            if (imageUrl != null)
            {
                return imageUrl;
            }

            return $"{folder}/{imageId}.{imageExtension}";
        }

        public static int GetAgeByDateOfBirth(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Now;

            if (now.Month > dateOfBirth.Month)
            {
                return now.Year - dateOfBirth.Year - 1;
            }
            else if (now.Day > dateOfBirth.Day)
            {
                return now.Year - dateOfBirth.Year - 1;
            }
            else
            {
                return now.Year - dateOfBirth.Year;
            }
        }
    }
}
