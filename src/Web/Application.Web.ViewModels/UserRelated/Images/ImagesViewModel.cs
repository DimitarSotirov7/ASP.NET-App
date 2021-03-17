namespace Application.Web.ViewModels
{
    using Application.Data.Common;
    using Application.Data.Models.Main;
    using Application.Services.Mapping;
    using AutoMapper;
    using System;

    public class ImagesViewModel : IMapFrom<Image>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Extension { get; set; }

        public string ImagePath { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Image, ImagesViewModel>()
                .ForMember(x => x.ImagePath, opt => opt.MapFrom(x => x.ImageUrl ??
                string.Format(GlobalConstants.GetsLocalImagePath, "/images/users/", x.Id, x.Extension)));
        }
    }
}
