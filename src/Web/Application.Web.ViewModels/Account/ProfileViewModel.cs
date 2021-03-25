namespace Application.Web.ViewModels.Account
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.Data.Common;
    using Application.Data.Models;
    using Application.Services.Mapping;
    using Application.Web.ViewModels.UserRelated;
    using Application.Web.ViewModels.UserRelated.Chats;
    using Application.Web.ViewModels.UserRelated.Posts;
    using AutoMapper;

    public class ProfileViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string SetProfileImageMessage { get; set; } = "Do you want to set it as a profile picture?";

        public string CurrentLoggedUser { get; set; }

        public string UserId { get; set; }

        public string ProfileImagePath { get; set; }

        public string CoverImagePath { get; set; }

        public string UserFullName { get; set; }

        public string AddressCity { get; set; }

        public string OtherImagesCount { get; set; }

        public string FollowersCount { get; set; }

        public string FollowingsCount { get; set; }

        public int Friends { get; set; }

        public FriendshipViewModel FriendShip { get; set; }

        public AllMessagesViewModel Chat { get; set; }

        public ICollection<ImagesViewModel> OtherImages { get; set; }

        public ICollection<PostViewModel> OwnPosts { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, ProfileViewModel>()
                .ForMember(x => x.ProfileImagePath, opt => opt.MapFrom(x =>
                GlobalConstants.GetProfileImagePath(x.ProfileImageId, x.ProfileImage.Extension, x.ProfileImage.ImageUrl)))
                .ForMember(x => x.CoverImagePath, opt => opt.MapFrom(x =>
                GlobalConstants.GetProfileImagePath(x.CoverImageId, x.CoverImage.Extension, x.CoverImage.ImageUrl)))
                .ForMember(x => x.UserFullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Friends, opt => opt.MapFrom(x =>
                    x.FriendshipRequests.Where(fr => fr.IsAccepted).Count() +
                    x.FriendshipResponses.Where(fr => fr.IsAccepted).Count()));
        }
    }
}
