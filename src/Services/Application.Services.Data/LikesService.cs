namespace Application.Services
{
    using System.Threading.Tasks;

    using Application.Data.Common.Repositories;
    using Application.Data.Models.Main;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated;

    public class LikesService : ILikesService
    {
        private readonly IRepository<Like> likesRepo;
        private readonly IDeletableEntityRepository<Image> imagesRepo;

        public LikesService(IRepository<Like> likesRepo, IDeletableEntityRepository<Image> imagesRepo)
        {
            this.likesRepo = likesRepo;
            this.imagesRepo = imagesRepo;
        }

        public async Task CreateLikeAsync(LikeInputModel input)
        {
            var like = new Like()
            {
                FromUserId = input.FromUserId,
                ToCommentId = input.ToCommentId,
                ToImageId = input.ToImageId,
                ToMessageId = input.ToMessageId,
                ToPostId = input.ToPostId,
            };

            await this.likesRepo.AddAsync(like);
            await this.likesRepo.SaveChangesAsync();
        }

        public int GetLikesByCommentId(int commentId)
        {
            // TODO: Get all likes
            return 0;
        }

        public int GetLikesByImageId(string imageId)
        {
            // TODO: Get all likes
            return 0;
        }

        public int GetLikesByMessageId(int messageId)
        {
            // TODO: Get all likes
            return 0;
        }

        public int GetLikesByPostId(int postId)
        {
            // TODO: Get all likes
            return 0;
        }
    }
}
