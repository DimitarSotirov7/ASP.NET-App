namespace Application.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Application.Models.Main;
    using Application.Web.ViewModels.UserRelated;
    using Application.Web.ViewModels.UserRelated.Post;

    public interface IPostsService
    {
        public Task CreatePostAsync(PostInputModel input, string imagePath);

        public ICollection<PostViewModel> GetAllLatestPosts(int countInPage, int currentPage);

        public ThumbUpDownCountsViewModel GetLikesAndDislikes(int postId);

        public Task LikePostAsync(int postId, string userId);

        public Task DislikePostAsync(int postId, string userId);

        public int GetCount();
    }
}
