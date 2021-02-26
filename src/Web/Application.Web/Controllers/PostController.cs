namespace Application.Web.Views.Home
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Application.Data.Models;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostController(IPostsService postsService, IUsersService usersService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.usersService = usersService;
            this.userManager = userManager;
        }

        public IActionResult All(int id = 1)
        {
            int postsPerPage = 5;

            var allLatestPosts = this.postsService.GetAllLatestPosts(id, postsPerPage);
            var posts = new AllLatestPostsViewModel()
            {
                Posts = allLatestPosts,
                CurrentPage = id,
                PostsPerPage = postsPerPage,
                PostsCount = this.postsService.GetCount(),
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

            input.FromUserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.postsService.CreatePostAsync(input);

            return this.RedirectToAction("All");
        }
    }
}
