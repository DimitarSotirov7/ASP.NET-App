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
    using Application.Services.Mapping;
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

        public ICollection<PostViewModel> GetAllLatestPosts(int currentPage, int countInPage = 10)
        {
            var countsToSkip = (currentPage - 1) * countInPage;

            return this.postsRepo.AllAsNoTracking()
                .Where(x => x.ToUserId == null)
                .OrderByDescending(x => x.CreatedOn)
                .Skip(countsToSkip).Take(countInPage)
                .To<PostViewModel>()
                .ToList();
        }

        public int GetCount()
        {
            return this.postsRepo.AllAsNoTracking().Count();
        }
    }
}
