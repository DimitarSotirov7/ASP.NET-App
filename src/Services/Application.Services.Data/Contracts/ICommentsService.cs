namespace Application.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Application.Models.Main;
    using Application.Web.ViewModels.UserRelated;

    public interface ICommentsService
    {
        public Task CreateCommentAsync(CommentInputModel input);

        public ICollection<Comment> GetCommentsByImageId(string imageId);

        public ICollection<Comment> GetCommentsByPostId(int postId);
    }
}
