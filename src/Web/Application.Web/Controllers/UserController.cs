namespace Application.Web.Controllers
{
    using Application.Services.Contracts;
    using Application.Web.ViewModels.Account;
    using Application.Web.ViewModels.UserRelated;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class UserController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IFriendshipsService friendshipsService;

        public UserController(IUsersService usersService, IFriendshipsService friendshipsService)
        {
            this.usersService = usersService;
            this.friendshipsService = friendshipsService;
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

            return this.View(profileViewModel);
        }
    }
}
