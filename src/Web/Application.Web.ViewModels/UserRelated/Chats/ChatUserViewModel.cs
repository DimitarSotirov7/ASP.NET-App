namespace Application.Web.ViewModels.UserRelated.Chats
{
    using Application.Data.Common;
    using Application.Data.Models;
    using Application.Services.Mapping;
    using AutoMapper;

    public class ChatUserViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string ProfileImagePath { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, ChatUserViewModel>()
                .ForMember(x => x.ProfileImagePath, opt => opt.MapFrom(x =>
                GlobalConstants.GetProfileImagePath(x.ProfileImageId, x.ProfileImage.Extension, x.ProfileImage.ImageUrl)));
        }
    }
}
