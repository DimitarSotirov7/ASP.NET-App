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
            comment.CommentedOn = DateTime.UtcNow;

            db.Comments.Add(comment);
            db.SaveChanges();

            return true;
        }

        public ICollection<Comment> GetCommentsByImageId(string imageId)
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
    }
}
