namespace Application.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated.Comments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class CommentController : BaseController
    {
        private readonly IPostsService postsService;

        public CommentController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpPost]
        public async Task<ActionResult<CommentViewModel>> OnPost(CommentInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            input.FromUserId = userId;

            await this.postsService.AddCommentAsync(input);

            var lastComment = this.postsService.GetLastComment(input);
            return lastComment;
        }
    }
}
