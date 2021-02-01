using Application.Models.UserStuffs;
using System.Collections.Generic;

namespace Application.Mapping.UserDTOModels
{
    public class GetUserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public string Joined { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordHint { get; set; }

        public Image ProfileImage { get; set; }

        public Image CoverImage { get; set; }

        public ICollection<Image> OtherImages { get; set; }
    }
}
