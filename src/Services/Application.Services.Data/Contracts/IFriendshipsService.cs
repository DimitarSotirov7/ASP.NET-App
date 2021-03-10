namespace Application.Services.Contracts
{
    using System.Threading.Tasks;

    using Application.Web.ViewModels.UserRelated;

    public interface IFriendshipsService
    {
        public Task CreateFriendshipAsync(FriendshipInputModel input);

        public bool FriendshipExist(FriendshipInputModel input);

        public FriendshipViewModel GetFriendship(FriendshipInputModel input);

        public Task AcceptFriendshipAsync(FriendshipInputModel input);

        public Task BlockFriendshipAsync(FriendshipInputModel input);

        public Task UnBlockFriendshipAsync(FriendshipInputModel input);

        public Task RemoveFriendshipAsync(FriendshipInputModel input);
    }
}
