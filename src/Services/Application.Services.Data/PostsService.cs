namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Data.Common.Repositories;
    using Application.Data.Models;
    using Application.Models.Main;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepo;

        public PostsService(IDeletableEntityRepository<Post> postsRepo, IDeletableEntityRepository<ApplicationUser> usersRepo)
        {
            this.postsRepo = postsRepo;
            this.usersRepo = usersRepo;
        }

        public async Task CreatePostAsync(PostInputModel input)
        {
            // var toUserId = this.usersRepo.AllAsNoTracking().FirstOrDefault(x => x.UserName == input.ToUserName).Id;
            var post = new Post()
            {
                Content = input.Content,
                ImageId = input.ImageId,
                FromUserId = input.FromUserId,
                ToUserId = null,
            };

            await this.postsRepo.AddAsync(post);
            await this.postsRepo.SaveChangesAsync();
        }

        public ICollection<PostViewModel> GetAllLatestPosts(int count)
        {
            return this.postsRepo.AllAsNoTracking()
                .Where(x => x.ToUserId == null)
                .OrderByDescending(x => x.CreatedOn)
                .Take(count)
                .Select(x => new PostViewModel()
                {
                    Content = x.Content,
                    FromUserName = this.usersRepo.AllAsNoTracking().FirstOrDefault(u => u.Id == x.FromUserId).UserName,
                    ToUserName = this.usersRepo.AllAsNoTracking().FirstOrDefault(u => u.Id == x.ToUserId).UserName,
                    ImageId = x.ImageId,
                    Time = DateTime.UtcNow - x.CreatedOn,
                })
                .ToList();
        }
    }
}
