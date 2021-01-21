using Application.Models.UserStuffs;

namespace Application.Services.Contracts
{
    public interface IFollowsService
    {
        public string CreateFollow(Follow follow);

        public Follow GetFollowById(int id);

        public Follow GetFollowByCreatorUsername(string creatorUsername);

        public Follow GetFollowByReceiverUsername(string receiverUsername);
    }
}
