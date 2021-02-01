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
            post.PostOn = DateTime.UtcNow;

            db.Posts.Add(post);
            db.SaveChanges();

            return true;
        }

        public GetPostDTO GetPostById(int id)
        {
            return db.Posts
                .Where(x => x.Id == id)
                .ProjectTo<GetPostDTO>(this.config)
                .FirstOrDefault();
        }

        public GetPostCommentsDTO GetPostCommentsById(int id)
        {
            return db.Posts
                .Where(x => x.Id == id)
                .ProjectTo<GetPostCommentsDTO>(this.config)
                .FirstOrDefault();
        }
    }
}
