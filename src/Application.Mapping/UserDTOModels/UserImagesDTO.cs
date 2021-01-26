using Application.Models.UserStuffs;
using System.Collections.Generic;

namespace Application.Mapping.UserDTOModels
{
    public class UserImagesDTO
    {
        public string ProfileImageUrl { get; set; }
        public byte[] ProfileImage { get; set; }

        public string CoverImageUrl { get; set; }
        public byte[] CoverImage { get; set; }

        public ICollection<Image> OtherImages { get; set; }
    }
}
