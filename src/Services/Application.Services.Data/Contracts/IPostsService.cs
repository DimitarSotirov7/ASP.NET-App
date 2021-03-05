namespace Application.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Web.ViewModels.UserRelated.Comments;
    using Application.Web.ViewModels.UserRelated.Posts;

    public interface IPostsService
    {
        public Task CreatePostAsync(PostInputModel input, string imagePath);

        public ICollection<PostViewModel> GetAllLatestPosts(int countInPage, int currentPage);

        public ThumbUpDownCountsViewModel GetLikesAndDislikes(int postId);

        public Task LikePostAsync(int postId, string userId);

        public Task DislikePostAsync(int postId, string userId);

        public Task AddCommentAsync(CommentInputModel input);

        public CommentViewModel GetLastComment(CommentInputModel input);

        public Task DeleteLikeDislikeFromPostByUser(int postId, string userId, bool isLike);

        public bool HasUserLikesInPost(string userId, int postId);

        public bool HasUserDislikesInPost(string userId, int postId);

        public int GetCount();
    }
}
