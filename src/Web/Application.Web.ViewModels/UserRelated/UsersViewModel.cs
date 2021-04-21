namespace Application.Web.ViewModels.UserRelated
{
    using Application.Data.Common;
    using Application.Data.Models;
    using Application.Services.Mapping;
    using AutoMapper;

    public class UsersViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string ProfileImagePath { get; set; }

        public string City { get; set; }

        public int Age { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UsersViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(x => x.ProfileImagePath, opt => opt.MapFrom(x =>
                GlobalConstants.GetProfileImagePath(x.ProfileImageId, x.ProfileImage.Extension, x.ProfileImage.ImageUrl)))
                .ForMember(x => x.Age, opt => opt.MapFrom(x => x.DateOfBirth == null ? 0 : GlobalConstants.GetAgeByDateOfBirth(x.DateOfBirth.Value)))
                .ForMember(x => x.City, opt => opt.MapFrom(x => x.Address.City));
        }
    }
}
