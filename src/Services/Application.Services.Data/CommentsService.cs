namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Data.Common.Repositories;
    using Application.Models.Main;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepo;
        private readonly IDeletableEntityRepository<Image> imagesRepo;
        private readonly IDeletableEntityRepository<Post> postsRepo;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepo, 
            IDeletableEntityRepository<Image> imagesRepo,
            IDeletableEntityRepository<Post> postsRepo)
        {
            this.commentsRepo = commentsRepo;
            this.imagesRepo = imagesRepo;
            this.postsRepo = postsRepo;
        }

        public async Task CreateCommentAsync(CommentInputModel input)
        {
            var comment = new Comment()
            {
                Content = input.Content,
                FromUserId = input.FromUserId,
                ToUserId = input.ToUserId,
            };

            await this.commentsRepo.AddAsync(comment);
            await this.commentsRepo.SaveChangesAsync();
        }

        public ICollection<Comment> GetCommentsByImageId(string imageId)
        {
            return this.imagesRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == imageId).Comments;
        }

        public ICollection<Comment> GetCommentsByPostId(int postId)
        {
            return this.postsRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == postId).Comments;
        }
    }
}
