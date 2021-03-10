namespace Application.Web.Controllers
{
    using Application.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Authorize]
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("/api/[controller]")]
    public class FriendshipController : BaseController
    {
        private readonly IFriendshipsService friendshipsService;

        public FriendshipController(IFriendshipsService friendshipsService)
        {
            this.friendshipsService = friendshipsService;
        }

        [HttpPost]
        public async Task<ActionResult> OnPost()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return null;
        }
    }
}
