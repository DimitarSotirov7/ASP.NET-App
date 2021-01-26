using Application.Mapping.PostDTOModels;
using Application.Models.UserStuffs;

namespace Application.Services.Contracts
{
    public interface IPostsService
    {
        public bool CreatePost(Post post);

        public PostInfoDTO GetPostInfoById(int id);

        public PostCommentsDTO GetPostCommentsById(int id);
    }
}
