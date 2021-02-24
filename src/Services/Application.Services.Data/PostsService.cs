namespace Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Application.Data.Common.Repositories;
    using Application.Models.Main;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepo;

        public PostsService(IDeletableEntityRepository<Post> postsRepo)
        {
            this.postsRepo = postsRepo;
        }

        public async Task CreatePostAsync(PostInputModel input)
        {
            var post = new Post()
            {
                Context = input.Context,
                ImageId = input.ImageId,
                FromUserId = input.FromUserId,
                ToUserId = input.ToUserId,
            };

            await this.postsRepo.AddAsync(post);
            await this.postsRepo.SaveChangesAsync();
        }

        public ICollection<Post> GetAllLatestPosts(int count)
        {
            throw new System.NotImplementedException();
        }
    }
}
