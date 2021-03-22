namespace Application.Web.ViewModels.Account
{
    using System.Collections.Generic;

    using Application.Data.Common;
    using Application.Data.Models;
    using Application.Services.Mapping;
    using Application.Web.ViewModels;
    using AutoMapper;

    public class UserImagesViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string ProfileImagePath { get; set; }

        public ICollection<ImagesViewModel> OtherImages { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserImagesViewModel>()
                .ForMember(x => x.ProfileImagePath, opt => opt.MapFrom(x => 
                GlobalConstants.GetProfileImagePath(x.ProfileImageId, x.ProfileImage.Extension, x.ProfileImage.ImageUrl)));
        }
    }
}
