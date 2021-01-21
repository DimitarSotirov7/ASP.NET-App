using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using System.Linq;

namespace Application.Services
{
    public class LikesService : ILikesService
    {
        private const string SuccessfullMessage = "Done!";

        private ApplicationDbContext db;

        public LikesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateLike(Like like)
        {
            if (like != null)
            {
                return null;
            }

            Like likeToCreate = new Like 
            {
                FromUserId = like.FromUserId,
                ToUserId = like.ToUserId
            };

            db.Likes.Add(likeToCreate);
            db.SaveChanges();

            return SuccessfullMessage;
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
