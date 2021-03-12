namespace Application.Web.Controllers
{
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class FriendshipController : BaseController
    {
        private readonly IFriendshipsService friendshipsService;

        public FriendshipController(IFriendshipsService friendshipsService)
        {
            this.friendshipsService = friendshipsService;
        }

        [HttpPost]
        public async Task<ActionResult<FriendshipViewModel>> OnPost(FriendshipInputModel input)
        {
            input.FromId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.friendshipsService.CreateFriendshipAsync(input);

            if (this.friendshipsService.FriendshipExist(input))
            {
                var view = new FriendshipViewModel { RequesterId = input.FromId, ResponderId = input.ToId };
                return view;
            }

            return null;
        }

        [HttpPut]
        public async Task<ActionResult<FriendshipViewModel>> OnPut(FriendshipInputModel input)
        {
            input.FromId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.friendshipsService.AcceptFriendshipAsync(input);

            if (this.friendshipsService.GetFriendship(input).IsAccepted)
            {
                var view = new FriendshipViewModel { RequesterId = input.FromId, ResponderId = input.ToId };
                return view;
            }

            return null;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FriendshipViewModel>> OnDelete(FriendshipInputModel input)
        {
            input.FromId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.friendshipsService.RemoveFriendshipAsync(input);

            if (!this.friendshipsService.FriendshipExist(input))
            {
                var view = new FriendshipViewModel { RequesterId = input.FromId, ResponderId = input.ToId };
                return view;
            }

            return null;
        }
    }
}
