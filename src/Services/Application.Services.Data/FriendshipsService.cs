namespace Application.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Data.Common.Repositories;
    using Application.Data.Models;
    using Application.Data.Models.Main;
    using Application.Services.Contracts;
    using Application.Services.Mapping;
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
            if (this.FriendshipExist(input))
            {
                return;
            }

            if (!this.BothUsersExist(input))
            {
                return;
            }

            Friendship friendship = new Friendship
            {
                RequesterId = input.FromId,
                ResponderId = input.ToId,
            };

            await this.friendshipsRepo.AddAsync(friendship);
            await this.friendshipsRepo.SaveChangesAsync();
        }

        public async Task AcceptFriendshipAsync(FriendshipInputModel input)
        {
            if (!this.BothUsersExist(input))
            {
                return;
            }

            var friendship = this.friendshipsRepo.AllAsNoTracking()
                .FirstOrDefault(x => x.RequesterId == input.FromId && x.ResponderId == input.ToId);

            if (friendship == null)
            {
                return;
            }

            friendship.IsAccepted = true;
            await this.friendshipsRepo.SaveChangesAsync();
        }

        public async Task BlockFriendshipAsync(FriendshipInputModel input)
        {
            if (!this.BothUsersExist(input))
            {
                return;
            }

            var friendship = this.friendshipsRepo.AllAsNoTracking()
                .FirstOrDefault(x => x.RequesterId == input.FromId && x.ResponderId == input.ToId);

            if (friendship == null)
            {
                return;
            }

            friendship.IsAccepted = false;
            friendship.IsBlocked = true;
            friendship.BlockedById = input.FromId;
            await this.friendshipsRepo.SaveChangesAsync();
        }

        public async Task RemoveFriendshipAsync(FriendshipInputModel input)
        {
            if (!this.BothUsersExist(input))
            {
                return;
            }

            var friendship = this.friendshipsRepo.AllAsNoTracking()
                .FirstOrDefault(x => x.RequesterId == input.FromId && x.ResponderId == input.ToId);

            if (friendship == null)
            {
                return;
            }

            // friendship.IsAccepted = false;
            // friendship.IsBlocked = false;
            // friendship.BlockedById = null;
            this.friendshipsRepo.Delete(friendship);
            await this.friendshipsRepo.SaveChangesAsync();
        }

        public async Task UnBlockFriendshipAsync(FriendshipInputModel input)
        {
            if (!this.BothUsersExist(input))
            {
                return;
            }

            var friendship = this.friendshipsRepo.AllAsNoTracking()
                .FirstOrDefault(x => x.RequesterId == input.FromId && x.ResponderId == input.ToId);

            if (friendship == null && friendship.BlockedById != input.FromId)
            {
                return;
            }

            friendship.IsAccepted = false;
            friendship.IsBlocked = false;
            friendship.BlockedById = null;
            await this.friendshipsRepo.SaveChangesAsync();
        }

        public bool FriendshipExist(FriendshipInputModel input)
        {
            return this.friendshipsRepo.AllAsNoTracking()
                .Any(x => x.RequesterId == input.FromId && x.ResponderId == input.ToId);
        }

        public FriendshipViewModel GetFriendship(FriendshipInputModel input)
        {
            return this.friendshipsRepo.AllAsNoTracking()
                .Where(x => x.RequesterId == input.FromId && x.ResponderId == input.ToId ||
                x.RequesterId == input.ToId && x.ResponderId == input.FromId)
                .To<FriendshipViewModel>()
                .FirstOrDefault();
        }

        private bool BothUsersExist(FriendshipInputModel input)
        {
            var requesterExist = this.usersRepo.AllAsNoTracking().Any(x => x.Id == input.FromId);
            var responderExist = this.usersRepo.AllAsNoTracking().Any(x => x.Id == input.ToId);
            if (requesterExist && responderExist)
            {
                return true;
            }

            return false;
        }
    }
}
