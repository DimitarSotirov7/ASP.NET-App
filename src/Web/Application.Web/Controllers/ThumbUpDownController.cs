namespace Application.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class ThumbUpDownController : BaseController
    {
        private readonly IPostsService postsService;

        public ThumbUpDownController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpPost]
        public async Task<ActionResult<ThumbUpDownCountsViewModel>> OnPost(ThumbUpDownInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (input.IsLike)
            {
                await this.postsService.LikePostAsync(input.PostId, userId);
            }
            else
            {
                await this.postsService.DislikePostAsync(input.PostId, userId);
            }

            var thumbs = this.postsService.GetLikesAndDislikes(input.PostId);

            return new ThumbUpDownCountsViewModel { LikesCount = thumbs.LikesCount, DislikesCount = thumbs.DislikesCount };
        }
    }
}
