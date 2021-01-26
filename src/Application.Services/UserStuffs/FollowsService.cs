using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            if (this.InvalidFollow(follow))
            {
                return false;
            }

            db.Follows.Add(follow);
            db.SaveChanges();

            return true;
        }

        public ICollection<Follow> GetFollowersByUserId(int userId)
        {
            return db.Users.Include(x => x.Followers).FirstOrDefault(x => x.Id == userId).Followers;
        }

        public ICollection<Follow> GetFollowingsByUserId(int userId)
        {
            return db.Users.Include(x => x.Followings).FirstOrDefault(x => x.Id == userId).Followings;
        }

        private bool InvalidFollow(Follow follow)
        {
            var fromUser = db.Users.FirstOrDefault(x => x.Id == follow.FromUserId);
            var toUser = db.Users.FirstOrDefault(x => x.Id == follow.ToUserId);

            return follow == null || (fromUser == null || toUser == null);
        }
    }
}
