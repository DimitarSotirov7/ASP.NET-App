namespace Application.Web.ViewModels.UserRelated
{
    using System;
    using System.Linq;
    using AutoMapper;

    using Application.Models.Main;
    using Application.Services.Mapping;

    public class PostViewModel : IMapFrom<Application.Models.Main.Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public string FromUserUserName { get; set; }

        public string FromUserProfileImagePath { get; set; }

        public string FromUserProfileImageId { get; set; }

        public string ToUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Application.Models.Main.Post, PostViewModel>()
                .ForMember(x => x.FromUserProfileImagePath, opt => 
                opt.MapFrom(x => "/images/users/" + x.FromUser.ProfileImageId + "." + x.FromUser.ProfileImage.Extension))
                .ForMember(x => x.ImagePath, opt => opt.MapFrom(x => !x.Images.Any() ? null :
                x.Images.FirstOrDefault().ImageUrl != null
                ? x.Images.FirstOrDefault().ImageUrl
                : "/images/posts/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
