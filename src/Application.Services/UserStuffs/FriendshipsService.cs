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
                .FirstOrDefault(x => x.RequesterId == requesterId && x.ResponderId == responderId);
            friendship.IsBlocked = true;
            db.SaveChanges();

            return true;
        }

        public bool CreateFriendship(int requesterId, int responderId)
        {
            var requester = db.Users.FirstOrDefault(x => x.Id == requesterId);
            var responder = db.Users.FirstOrDefault(x => x.Id == responderId);

            var existFriendShip = db.Friendships
                .FirstOrDefault(x => x.RequesterId == requesterId && x.ResponderId == responderId);

            if (requester == null || responder == null || existFriendShip != null)
            {
                return false;
            }

            Friendship friendship = new Friendship
            {
                RequesterId = db.Users.FirstOrDefault(x => x.Id == requesterId).Id,
                ResponderId = db.Users.FirstOrDefault(x => x.Id == responderId).Id,
                IsAccepted = false,
                IsBlocked = false
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
                .FirstOrDefault(x => x.RequesterId == requesterId && x.ResponderId == responderId);
            friendship.IsAccepted = false;
            friendship.IsBlocked = false;
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
                .FirstOrDefault(x => x.RequesterId == requesterId && x.ResponderId == responderId);
            friendship.IsBlocked = false;
            friendship.IsAccepted = false;
            db.SaveChanges();

            return true;
        }
    }
}
