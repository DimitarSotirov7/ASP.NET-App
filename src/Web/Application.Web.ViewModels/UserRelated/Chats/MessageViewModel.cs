namespace Application.Web.ViewModels.UserRelated.Chats
{
    using System;

    using Application.Data.Common;
    using Application.Data.Models.Main;
    using Application.Services.Mapping;
    using AutoMapper;

    public class MessageViewModel : IMapFrom<Message>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string FromUserId { get; set; }

        public string FromUserProfileImagePath { get; set; }

        public string ToUserId { get; set; }

        public string ToUserProfileImagePath { get; set; }

        public string LoggedUser { get; set; }

        public string ImageId { get; set; }

        public bool Seen { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Message, MessageViewModel>()
                .ForMember(x => x.FromUserProfileImagePath, opt => opt.MapFrom(x =>
                GlobalConstants.GetProfileImagePath(x.FromUser.ProfileImageId, x.FromUser.ProfileImage.Extension, x.FromUser.ProfileImage.ImageUrl)))
                .ForMember(x => x.ToUserProfileImagePath, opt => opt.MapFrom(x =>
                GlobalConstants.GetProfileImagePath(x.ToUser.ProfileImageId, x.ToUser.ProfileImage.Extension, x.ToUser.ProfileImage.ImageUrl)));
        }
    }
}
