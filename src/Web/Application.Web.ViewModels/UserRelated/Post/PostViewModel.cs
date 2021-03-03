namespace Application.Web.ViewModels.UserRelated
{
    using System;
    using System.Linq;
    using Application.Models.Main;
    using Application.Services.Mapping;
    using AutoMapper;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string ImagePath { get; set; }

        public string FromUserName { get; set; }

        public string ToUserName { get; set; }

        public TimeSpan Time { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.Time, opt => opt.MapFrom(x => DateTime.UtcNow - x.CreatedOn));

            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.FromUserName, opt => opt.MapFrom(x => x.FromUser.UserName));

            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.ImagePath, opt => opt.MapFrom(x => !x.Images.Any() ? null :
                x.Images.FirstOrDefault().ImageUrl != null
                ? x.Images.FirstOrDefault().ImageUrl
                : "/images/posts/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
