using Application.Mapping.PostDTOModels;
using Application.Models.UserStuffs;

namespace Application.Services.Contracts
{
    public interface IPostsService
    {
        public bool CreatePost(Post post);

        public GetPostDTO GetPostById(int id);

        public GetPostCommentsDTO GetPostCommentsById(int id);
    }
}
