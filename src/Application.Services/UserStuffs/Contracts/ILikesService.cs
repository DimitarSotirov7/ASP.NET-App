using Application.Models.UserStuffs;

namespace Application.Services.Contracts
{
    public interface ILikesService
    {
        public bool CreateLike(Like like);

        public int GetLikesByImageId(string imageId);

        public int GetLikesByPostId(int postId);
    }
}
