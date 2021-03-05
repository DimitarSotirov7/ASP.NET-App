namespace Application.Web.Views.Home
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Application.Data.Common;
    using Application.Data.Models;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public PostController(IPostsService postsService, IUsersService usersService, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            this.postsService = postsService;
            this.usersService = usersService;
            this.userManager = userManager;
            this.environment = environment;
        }

        public IActionResult All(int id = 1)
        {
            if (id < 0)
            {
                return this.NotFound();
            }

            int postsPerPage = 5;

            var allLatestPosts = this.postsService.GetAllLatestPosts(id, postsPerPage);

            var profileImagePath = this.usersService.GetUserImages(this.User.FindFirst(ClaimTypes.NameIdentifier).Value).ProfileImagePath;
            if (profileImagePath == null)
            {
                profileImagePath = "/images/" + GlobalConstants.DefaultProfileImageName;
            }

            var posts = new AllLatestPostsViewModel()
            {
                Posts = allLatestPosts,
                CurrentPage = id,
                PostsPerPage = postsPerPage,
                PostsCount = this.postsService.GetCount(),
                LoggedUserProfileImagePath = profileImagePath,
            };

            return this.View(posts);
        }

        public IActionResult Create()
        {
            var postInputModel = new PostInputModel();

            return this.View(postInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var postInputModel = new PostInputModel();

                return this.View(postInputModel);
            }

            var imagePath = $"{this.environment.WebRootPath}/images/posts";

            input.FromUserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.postsService.CreatePostAsync(input, imagePath);

            return this.RedirectToAction("All");
        }
    }
}
