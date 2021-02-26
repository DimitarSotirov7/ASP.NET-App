namespace Application.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Application.Models.Main;
    using Application.Web.ViewModels.UserRelated;

    public interface IPostsService
    {
        public Task CreatePostAsync(PostInputModel input);

        public ICollection<PostViewModel> GetAllLatestPosts(int countInPage, int currentPage);

        public int GetCount();
    }
}
