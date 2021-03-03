namespace Application.Web.ViewModels.Account
{
    using Application.Data.Models;
    using Application.Models.Main;
    using Application.Services.Mapping;
    using AutoMapper;
    using System.Collections.Generic;
    using Application.Web.ViewModels;

    public class UserImagesViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string ProfileImagePath { get; set; }

        public ICollection<ImagesViewModel> OtherImages { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserImagesViewModel>()
                .ForMember(x => x.ProfileImagePath, opt => opt.MapFrom(x => "/images/users/" + x.ProfileImageId + "." + x.ProfileImage.Extension));
        }
    }
}
