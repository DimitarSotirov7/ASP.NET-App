namespace Application.Web.Controllers
{
    using System.Security.Claims;

    using Application.Services.Contracts;
    using Application.Web.ViewModels.Account;
    using Application.Web.ViewModels.UserRelated;
    using Application.Web.ViewModels.UserRelated.Chats;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UserController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IFriendshipsService friendshipsService;
        private readonly IMessagesService messagesService;

        public UserController(IUsersService usersService, IFriendshipsService friendshipsService, IMessagesService messagesService)
        {
            this.usersService = usersService;
            this.friendshipsService = friendshipsService;
            this.messagesService = messagesService;
        }

        public IActionResult Images()
        {
            return this.View();
        }

        public IActionResult Profile(string id)
        {
            var profileViewModel = this.usersService.GetUser<ProfileViewModel>(id);
            profileViewModel.CurrentLoggedUser = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var friendshipInputModel = new FriendshipInputModel
            {
                FromId = profileViewModel.CurrentLoggedUser,
                ToId = profileViewModel.UserId,
            };
            profileViewModel.FriendShip = this.friendshipsService.GetFriendship(friendshipInputModel);

            if (profileViewModel.FriendShip != null && profileViewModel.FriendShip.IsBlocked)
            {
                this.Redirect("/post/all");
            }

            profileViewModel.Chat = new AllMessagesViewModel
            {
                Messages = this.messagesService
                    .GetMessagesByUserIds<MessageViewModel>(this.User.FindFirst(ClaimTypes.NameIdentifier).Value, id),
                LoggedUserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value,
            };

            return this.View(profileViewModel);
        }
    }
}
