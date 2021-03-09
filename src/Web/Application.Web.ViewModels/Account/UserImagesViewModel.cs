namespace Application.Web.ViewModels.Account
{
    using Application.Data.Models;
    using Application.Services.Mapping;
    using AutoMapper;
    using System.Collections.Generic;
    using Application.Web.ViewModels;
    using Application.Data.Common;

    public class UserImagesViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string ProfileImagePath { get; set; }

        public ICollection<ImagesViewModel> OtherImages { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserImagesViewModel>()
                .ForMember(x => x.ProfileImagePath, opt => opt.MapFrom(x =>
                string.Format(GlobalConstants.GetsLocalImagePath, "images/users", x.ProfileImageId, x.ProfileImage.Extension)));
        }
    }
}
