namespace Application.Web.ViewModels.Account
{
    using Application.Data.Common;
    using Application.Data.Models;
    using Application.Services.Mapping;
    using AutoMapper;

    public class ProfileViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string UserId { get; set; }

        public string ProfileImagePath { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, ProfileViewModel>()
                .ForMember(x => x.ProfileImagePath, opt =>
                opt.MapFrom(x => x.ProfileImage == null
                    ? string.Format(GlobalConstants.GetsDefaultProfileImagePath, "images")
                    : string.Format(GlobalConstants.GetsLocalImagePath, "images/users", x.ProfileImageId, x.ProfileImage.Extension)));
        }
    }
}
