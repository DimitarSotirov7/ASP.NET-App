namespace Application.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<IActionResult> ChangeProfileImage(string imageId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.usersService.SetProfilePicture(userId, imageId);

            return this.Redirect("/User/Profile/" + userId);
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
                LoggedUserProfileImagePath = this.usersService
                    .GetUserImages(this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                    .ProfileImagePath,
            };

            return this.View(profileViewModel);
        }
    }
}
