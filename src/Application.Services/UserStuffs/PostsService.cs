using Application.Data;
using Application.Mapping.PostDTOModels;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Linq;

namespace Application.Services
{
    public class PostsService : IPostsService
    {
        private ApplicationDbContext db;
        private MapperConfiguration config;

        public PostsService(ApplicationDbContext db, MapperConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public bool CreatePost(Post post)
        {
            if (this.InvalidPost(post))
            {
                return false;
            }

            post.PostOn = DateTime.Now;

            db.Posts.Add(post);
            db.SaveChanges();

            return true;
        }

        public PostCommentsDTO GetPostCommentsById(int id)
        {
            return db.Posts
                .Where(x => x.Id == id)
                .ProjectTo<PostCommentsDTO>(this.config)
                .FirstOrDefault();
        }

        public PostInfoDTO GetPostInfoById(int id)
        {
            return db.Posts
                .Where(x => x.Id == id)
                .ProjectTo<PostInfoDTO>(this.config)
                .FirstOrDefault();
        }

        private bool InvalidPost(Post post)
        {
            var fromUser = db.Users.FirstOrDefault(x => x.Id == post.FromUserId);

            return post == null || (post.Context == null || fromUser == null);
        }
    }
}
