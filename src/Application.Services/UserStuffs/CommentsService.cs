using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using System;
using System.Linq;

namespace Application.Services
{
    public class CommentsService : ICommentsService
    {
        private ApplicationDbContext db;

        public CommentsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool CreateComment(Comment comment)
        {
            bool requiredInfo = comment != null && comment.Context != null;

            if (!requiredInfo)
            {
                return false;
            }

            Comment commentToCreate = new Comment
            {
                Context = comment.Context,
                FromUserId = comment.FromUserId,
                ToUserId = comment.ToUserId,
                ImageId = comment.ImageId ?? null,
                CommentedOn = DateTime.Now
            };

            db.Comments.Add(commentToCreate);
            db.SaveChanges();

            return true;
        }

        public Comment GetCommentByCreatorUsername(string creatorUsername)
        {
            return db.Comments.FirstOrDefault(x => x.FromUser.Username == creatorUsername);
        }

        public Comment GetCommentById(int id)
        {
            return db.Comments.FirstOrDefault(x => x.Id == id);
        }

        public Comment GetCommentByReceiverUsername(string receiverUsername)
        {
            return db.Comments.FirstOrDefault(x => x.ToUser.Username == receiverUsername);
        }
    }
}
