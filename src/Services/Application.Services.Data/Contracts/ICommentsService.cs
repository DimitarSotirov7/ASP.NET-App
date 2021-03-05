namespace Application.Services.Contracts
{
    using System.Threading.Tasks;

    using Application.Web.ViewModels.UserRelated.Comments;

    public interface ICommentsService
    {
        public Task CreateCommentAsync(CommentInputModel input);
    }
}
