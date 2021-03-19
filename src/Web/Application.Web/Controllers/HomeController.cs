namespace Application.Web.Controllers
{
    using System.Diagnostics;
    using System.Security.Claims;

    using Application.Services.Contracts;
    using Application.Web.ViewModels;
    using Application.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                UsersCount = this.usersService.GetUsersCount(),
            };

            return this.View(homeViewModel);
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult Contact()
        {
            var viewModel = this.usersService
                .GetEmailUserInfo<EmailInputModel>(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return this.View(viewModel);
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
