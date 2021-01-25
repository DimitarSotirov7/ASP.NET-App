using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using System.Linq;

namespace Application.Services
{
    public class FriendshipsService : IFriendshipsService
    {
        private const string SuccessfullMessage = "Done!";

        private ApplicationDbContext db;

        public FriendshipsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string AcceptFriendship(int requesterId, int responderId)
        {
            var requester = db.Users.FirstOrDefault(x => x.Id == requesterId);
            var responder = db.Users.FirstOrDefault(x => x.Id == responderId);

            if (requester == null || responder == null)
            {
                return null;
            }

            var friendship = db.Friendships
                .FirstOrDefault(x => x.RequesterId == requesterId && x.ResponderId == responderId);
            friendship.IsAccepted = true;
            db.SaveChanges();

            return SuccessfullMessage;
        }

        public string CreateFriendship(int requesterId, int responderId)
        {
            Friendship friendship = new Friendship
            {
                RequesterId = db.Users.FirstOrDefault(x => x.Id == requesterId).Id,
                ResponderId = db.Users.FirstOrDefault(x => x.Id == responderId).Id,
                IsAccepted = false
            };

            db.Friendships.Add(friendship);
            db.SaveChanges();

            return SuccessfullMessage;
        }

        public string RemoveFriendship(int requesterId, int responderId)
        {
            var requester = db.Users.FirstOrDefault(x => x.Id == requesterId);
            var responder = db.Users.FirstOrDefault(x => x.Id == responderId);

            if (requester == null || responder == null)
            {
                return null;
            }

            var friendship = db.Friendships
                .FirstOrDefault(x => x.RequesterId == requesterId && x.ResponderId == responderId);
            friendship.IsAccepted = false;
            db.SaveChanges();

            return SuccessfullMessage;
        }
    }
}
