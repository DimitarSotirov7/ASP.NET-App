namespace Application.Services.Contracts
{
    using System.Threading.Tasks;

    using Application.Web.ViewModels.UserRelated;

    public interface ILikesService
    {
        public Task CreateLikeAsync(LikeInputModel input);

        public int GetLikesByImageId(string imageId);

        public int GetLikesByPostId(int postId);

        public int GetLikesByCommentId(int commentId);

        public int GetLikesByMessageId(int messageId);
    }
}
