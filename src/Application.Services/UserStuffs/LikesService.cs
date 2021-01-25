using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using System.Linq;

namespace Application.Services
{
    public class LikesService : ILikesService
    {
        private ApplicationDbContext db;

        public LikesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool CreateLike(Like like)
        {
            if (like != null)
            {
                return false;
            }

            Like likeToCreate = new Like 
            {
                FromUserId = like.FromUserId,
                ToUserId = like.ToUserId
            };

            db.Likes.Add(likeToCreate);
            db.SaveChanges();

            return true;
        }

        public Like GetLikeByCreatorUsername(string creatorUsername)
        {
            return db.Likes.FirstOrDefault(x => x.FromUser.Username == creatorUsername);
        }

        public Like GetLikeById(int id)
        {
            return db.Likes.FirstOrDefault(x => x.Id == id);
        }

        public Like GetLikeByReceiverUsername(string receiverUsername)
        {
            return db.Likes.FirstOrDefault(x => x.ToUser.Username == receiverUsername);
        }
    }
}
