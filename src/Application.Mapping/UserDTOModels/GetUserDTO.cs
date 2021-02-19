using Application.Models.UserStuffs;
using System;
using System.Collections.Generic;

namespace Application.Mapping.UserDTOModels
{
    public class GetUserDTO
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime Joined { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordHint { get; set; }

        public Image ProfileImage { get; set; }

        public Image CoverImage { get; set; }

        public ICollection<Image> OtherImages { get; set; }
    }
}
