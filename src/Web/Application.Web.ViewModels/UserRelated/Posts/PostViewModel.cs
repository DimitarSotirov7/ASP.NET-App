namespace Application.Web.ViewModels.UserRelated.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.Data.Common;
    using Application.Data.Models.Main;
    using Application.Services.Mapping;
    using Application.Web.ViewModels.UserRelated.Comments;
    using AutoMapper;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public string FromUserUserName { get; set; }

        public string UserId { get; set; }

        public string FromUserProfileImagePath { get; set; }

        public string FromUserProfileImageId { get; set; }

        public string ToUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.FromUserProfileImagePath, opt =>
                opt.MapFrom(x => x.FromUser.ProfileImage == null
                    ? string.Format(GlobalConstants.GetsDefaultProfileImagePath, @"\images\")
                    : string.Format(GlobalConstants.GetsLocalImagePath, @"\images\users\", x.FromUser.ProfileImageId, x.FromUser.ProfileImage.Extension)))
                .ForMember(x => x.ImagePath, opt => opt.MapFrom(x => !x.Images.Any() ? null
                : x.Images.FirstOrDefault().ImageUrl ??
                string.Format(GlobalConstants.GetsLocalImagePath, @"\images\posts\", x.Images.FirstOrDefault().Id, x.Images.FirstOrDefault().Extension)))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.FromUserId));
        }
    }
}
