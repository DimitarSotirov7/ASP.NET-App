﻿using Application.Data;
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
            db.Likes.Add(like);
            db.SaveChanges();

            return true;
        }

        public int GetLikesByImageId(string imageId)
        {
            return db.Images.Where(x => x.Id == imageId).Sum(x => x.Likes.Count);
        }

        public int GetLikesByPostId(int postId)
        {
            return db.Posts.Where(x => x.Id == postId).Sum(x => x.Likes.Count);
        }
    }
}
