using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using System;
using System.Linq;

namespace Application.Services
{
    public class PostsService : IPostsService
    {
        private const string SuccessfullMessage = "Done!";

        private ApplicationDbContext db;

        public PostsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreatePost(Post post)
        {
            bool requiredInfo = post != null && post.Context != null;

            if (!requiredInfo)
            {
                return null;
            }

            Post postToCreate = new Post 
            {
                Context = post.Context,
                ImageId = post.ImageId ?? null,
                FromUserId = post.FromUserId,
                ToUserId = post.ToUserId ?? null,
                PostOn = DateTime.Now
            };

            db.Posts.Add(postToCreate);
            db.SaveChanges();

            return SuccessfullMessage;
        }

        public Post GetPostByCreatorUsername(string creatorUsername)
        {
            return db.Posts.FirstOrDefault(x => x.FromUser.Username == creatorUsername);
        }

        public Post GetPostById(int id)
        {
            return db.Posts.FirstOrDefault(x => x.Id == id);
        }

        public Post GetPostByReceiverUsername(string receiverUsername)
        {
            return db.Posts.FirstOrDefault(x => x.ToUser.Username == receiverUsername);
        }
    }
}
