namespace Application.Services
{
    using System.Threading.Tasks;

    using Application.Data.Common.Repositories;
    using Application.Data.Models.Main;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated.Comments;

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
                
            };

            await this.commentsRepo.AddAsync(comment);
            await this.commentsRepo.SaveChangesAsync();
        }
    }
}
