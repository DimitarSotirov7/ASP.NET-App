namespace Application.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Claims;

    using Application.Data.Models;
    using Application.Services.Contracts;
    using Application.Web.ViewModels;
    using Application.Web.ViewModels.Home;
    using Application.Web.ViewModels.UserRelated.Chats;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IUsersService usersService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public HomeController(IUsersService usersService, SignInManager<ApplicationUser> signInManager)
        {
            this.usersService = usersService;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var chatsViewModel = new ChatsViewModel();

            if (this.signInManager.IsSignedIn(this.User))
            {
                chatsViewModel.Users = this.usersService.GetAllUsers<ChatUserViewModel>()
                    .Where(x => x.Id != this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                    .ToList();
            }

            var homeViewModel = new HomeViewModel()
            {
                ChatsViewModel = chatsViewModel,
            };

            return this.View(homeViewModel);
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult Contact()
        {
            if (this.signInManager.IsSignedIn(this.User))
            {
                var viewModel = this.usersService
                .GetEmailUserInfo<EmailInputModel>(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                return this.View(viewModel);
            }

            return this.View(new EmailInputModel());
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
