using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using System.Linq;

namespace Application.Services
{
    public class FriendshipsService : IFriendshipsService
    {
        private ApplicationDbContext db;

        public FriendshipsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool AcceptFriendship(int requesterId, int responderId)
        {
            var requester = db.Users.FirstOrDefault(x => x.Id == requesterId);
            var responder = db.Users.FirstOrDefault(x => x.Id == responderId);

            if (requester == null || responder == null)
            {
                return false;
            }

            var friendship = db.Friendships
                .FirstOrDefault(x => x.RequesterId == requesterId && x.ResponderId == responderId);

            if (friendship == null)
            {
                return false;
            }

            friendship.IsAccepted = true;
            db.SaveChanges();

            return true;
        }

        public bool BlockFriendship(int requesterId, int responderId)
        {
            var requester = db.Users.FirstOrDefault(x => x.Id == requesterId);
            var responder = db.Users.FirstOrDefault(x => x.Id == responderId);

            if (requester == null || responder == null)
            {
                return false;
            }

            var friendship = db.Friendships
                .FirstOrDefault(x => (x.RequesterId == requesterId || x.RequesterId == responderId) && 
                (x.ResponderId == requesterId || x.ResponderId == responderId));

            if (friendship == null)
            {
                return false;
            }

            friendship.IsAccepted = false;
            friendship.IsBlocked = true;
            friendship.BlockedById = requesterId;
            db.SaveChanges();

            return true;
        }

        public bool CreateFriendship(int requesterId, int responderId)
        {
            var existFriendShip = db.Friendships
                .Any(x => x.RequesterId == requesterId && x.ResponderId == responderId);

            if (existFriendShip)
            {
                return false;
            }

            var requester = db.Users.FirstOrDefault(x => x.Id == requesterId);
            var responder = db.Users.FirstOrDefault(x => x.Id == responderId);

            if (requester == null || responder == null)
            {
                return false;
            }

            Friendship friendship = new Friendship
            {
                RequesterId = requesterId,
                ResponderId = responderId
            };

            db.Friendships.Add(friendship);
            db.SaveChanges();

            return true;
        }

        public bool RemoveFriendship(int requesterId, int responderId)
        {
            var requester = db.Users.FirstOrDefault(x => x.Id == requesterId);
            var responder = db.Users.FirstOrDefault(x => x.Id == responderId);

            if (requester == null || responder == null)
            {
                return false;
            }

            var friendship = db.Friendships
               .FirstOrDefault(x => (x.RequesterId == requesterId || x.RequesterId == responderId) &&
               (x.ResponderId == requesterId || x.ResponderId == responderId));

            if (friendship == null)
            {
                return false;
            }

            friendship.Requester = null;
            friendship.Responder = null;
            friendship.BlockedBy = null;

            db.Friendships.Remove(friendship);
            db.SaveChanges();

            return true;
        }

        public bool UnBlockFriendship(int requesterId, int responderId)
        {
            var requester = db.Users.FirstOrDefault(x => x.Id == requesterId);
            var responder = db.Users.FirstOrDefault(x => x.Id == responderId);

            if (requester == null || responder == null)
            {
                return false;
            }

            var friendship = db.Friendships
                .FirstOrDefault(x => (x.RequesterId == requesterId || x.RequesterId == responderId) &&
                (x.ResponderId == requesterId || x.ResponderId == responderId));

            if (friendship == null)
            {
                return false;
            }

            if (friendship.BlockedById != requesterId)
            {
                return false;
            }

            friendship.IsBlocked = false;
            friendship.IsAccepted = false;
            friendship.BlockedById = null;
            db.SaveChanges();

            return true;
        }
    }
}
