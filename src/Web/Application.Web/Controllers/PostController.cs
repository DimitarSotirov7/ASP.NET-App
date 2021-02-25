namespace Application.Web.Views.Home
{
    using System.Threading.Tasks;

    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IUsersService usersService;

        public PostController(IPostsService postsService, IUsersService usersService)
        {
            this.postsService = postsService;
            this.usersService = usersService;
        }

        public IActionResult All()
        {
            var allLatestPosts = this.postsService.GetAllLatestPosts(10);
            var posts = new AllLatestPostsViewModel() { Posts = allLatestPosts };

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

            input.FromUserId = this.usersService.GetUserIdByUsernameAndPassword(this.User.Identity.Name);
            await this.postsService.CreatePostAsync(input);

            return this.RedirectToAction("All");
        }
    }
}
