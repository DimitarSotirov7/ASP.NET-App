namespace Application.Web.Areas.Identity.Pages.Account.Manage
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc;

    using Application.Data.Models;
    using Application.Web.ViewModels.Account;
    using Application.Services.Contracts;
    using Microsoft.AspNetCore.Hosting;
    using System.Security.Claims;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUsersService usersService;
        private readonly IWebHostEnvironment environment;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUsersService usersService,
            IWebHostEnvironment environment)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.usersService = usersService;
            this.environment = environment;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public ProfileInputModel Input { get; set; }

        // private async Task LoadAsync(ApplicationUser user)
        // {
        // }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this._userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this._userManager.GetUserId(this.User)}'.");
            }

            // await this.LoadAsync(user);
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await this._userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this._userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                // await this.LoadAsync(user);
                return this.Page();
            }

            var userimagesPath = $"{this.environment.WebRootPath}/images/users";
            await this.usersService.UploadUserImagesAsync
                (this.User.FindFirst(ClaimTypes.NameIdentifier).Value, this.Input.LocalImages, this.Input.ImageUrl, userimagesPath);

            await this._signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";
            return this.RedirectToPage();
        }
    }
}
