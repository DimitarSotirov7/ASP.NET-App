namespace Application.Web.ViewModels.UserRelated
{
    using Application.Data.Models.Main;
    using Application.Services.Mapping;
    using AutoMapper;

    public class FriendshipViewModel : IMapFrom<Friendship>
    {
        public bool IsAccepted { get; set; }

        public bool IsBlocked { get; set; }

        public string BlockedById { get; set; }

        public string RequesterId { get; set; }

        public string ResponderId { get; set; }
    }
}
