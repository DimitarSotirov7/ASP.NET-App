namespace Application.Web.Controllers
{
    using Application.Services.Contracts;
    using Application.Web.ViewModels.Account;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : Controller
    {
        private readonly IUsersService usersService;

        public UserController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Images()
        {
            return this.View();
        }

        public IActionResult Profile(string id)
        {
            var profileViewModel = new ProfileViewModel{ UserId = id };

            return this.View(profileViewModel);
        }
    }
}
