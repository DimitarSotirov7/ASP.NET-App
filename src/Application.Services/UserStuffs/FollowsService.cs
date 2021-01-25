using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using System.Linq;

namespace Application.Services
{
    public class FollowsService : IFollowsService
    {
        private ApplicationDbContext db;

        public FollowsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool CreateFollow(Follow follow)
        {
            bool requiredInfo = follow != null;

            if (!requiredInfo)
            {
                return false;
            }

            Follow followToCreate = new Follow
            {
                FromUserId = follow.FromUserId,
                ToUserId = follow.ToUserId,
            };

            db.Follows.Add(followToCreate);
            db.SaveChanges();

            return true;
        }

        public Follow GetFollowByCreatorUsername(string creatorUsername)
        {
            return db.Follows.FirstOrDefault(x => x.FromUser.Username == creatorUsername);
        }

        public Follow GetFollowById(int id)
        {
            return db.Follows.FirstOrDefault(x => x.Id == id);
        }

        public Follow GetFollowByReceiverUsername(string receiverUsername)
        {
            return db.Follows.FirstOrDefault(x => x.ToUser.Username == receiverUsername);
        }
    }
}
