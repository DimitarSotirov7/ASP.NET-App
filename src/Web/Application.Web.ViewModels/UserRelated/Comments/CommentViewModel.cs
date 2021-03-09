namespace Application.Web.ViewModels.UserRelated.Comments
{
    using Application.Data.Common;
    using Application.Data.Models.Main;
    using Application.Services.Mapping;
    using AutoMapper;
    using System;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string FromUsername { get; set; }

        public string FromUserId { get; set; }

        public string FromUserProfileImagePath { get; set; }

        public int? ToPostId { get; set; }

        public string ToImageId { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.FromUsername, opt =>
                opt.MapFrom(x => x.FromUser.UserName))
                .ForMember(x => x.FromUserProfileImagePath, opt =>
                opt.MapFrom(x => x.FromUser.ProfileImage == null
                    ? "/images/" + GlobalConstants.DefaultProfileImageName
                    : "/images/users/" + x.FromUser.ProfileImageId + "." + x.FromUser.ProfileImage.Extension));
        }
    }
}
