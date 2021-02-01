using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            if (this.InvalidComment(comment))
            {
                return false;
            }

            comment.CommentedOn = DateTime.UtcNow;

            db.Comments.Add(comment);
            db.SaveChanges();

            return true;
        }

        public ICollection<Comment> GetCommentsByImageId(int imageId)
        {
            return db.Images
                .Include(x => x.Comments)
                .FirstOrDefault(x => x.Id == imageId)
                .Comments.OrderBy(x => x.CommentedOn).ToList();
        }

        public ICollection<Comment> GetCommentsByPostId(int postId)
        {
            return db.Posts
                .Include(x => x.Comments)
                .FirstOrDefault(x => x.Id == postId)
                .Comments.OrderBy(x => x.CommentedOn).ToList();
        }

        private bool InvalidComment(Comment comment)
        {
            var fromUser = db.Users.FirstOrDefault(x => x.Id == comment.FromUserId);
            var toUser = db.Users.FirstOrDefault(x => x.Id == comment.ToUserId);

            return comment == null || 
                (comment.Context == null && comment.Image == null && comment.ImageUrl == null) ||
                (fromUser == null || toUser == null);
        }
    }
}
