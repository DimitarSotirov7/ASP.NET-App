namespace Application.Services
{
    using System.Threading.Tasks;

    using Application.Data.Common.Repositories;
    using Application.Data.Models;
    using Application.Models.Main;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated;

    public class FriendshipsService : IFriendshipsService
    {
        private readonly IRepository<Friendship> friendshipsRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepo;

        public FriendshipsService(IRepository<Friendship> friendshipsRepo, IDeletableEntityRepository<ApplicationUser> usersRepo)
        {
            this.friendshipsRepo = friendshipsRepo;
            this.usersRepo = usersRepo;
        }

        public async Task CreateFriendshipAsync(FriendshipInputModel input)
        {
            // TODO: Check if friendship exists
            // TODO: Get requester
            // TODO: Get responder
            // TODO: Check if both exist

            Friendship friendship = new Friendship
            {
                RequesterId = input.FomId,
                ResponderId = input.ToId,
            };

            await this.friendshipsRepo.AddAsync(friendship);
            await this.friendshipsRepo.SaveChangesAsync();
        }

        public async Task AcceptFriendshipAsync(FriendshipInputModel input)
        {
            // TODO: Get requester
            // TODO: Get responder
            // TODO: Check if both exist
            // TODO: Get friendship
            // TODO: Check if friendship exists
            // TODO: Accept friendship and save changes
        }

        public async Task BlockFriendshipAsync(FriendshipInputModel input)
        {
            // TODO: Get requester
            // TODO: Get responder
            // TODO: Check if both exist
            // TODO: Get friendship
            // TODO: Check if friendship exists
            // TODO: Set accept as false, block friendship, set blockedById and save changes
        }


        public async Task RemoveFriendshipAsync(FriendshipInputModel input)
        {
            // TODO: Get requester
            // TODO: Get responder
            // TODO: Check if both exist
            // TODO: Get friendship
            // TODO: Check if friendship exists
            // TODO: Remove friendship and save changes
        }

        public async Task UnBlockFriendshipAsync(FriendshipInputModel input)
        {
            // TODO: Get requester
            // TODO: Get responder
            // TODO: Check if both exist
            // TODO: Get friendship
            // TODO: Check if friendship exists and is blocked
            // TODO: Check if blockedById = input.FromId
            // TODO: Set block as false, set blockedById as null and save changes
        }
    }
}
