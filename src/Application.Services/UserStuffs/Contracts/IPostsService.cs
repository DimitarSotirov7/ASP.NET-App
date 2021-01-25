using Application.Models.UserStuffs;

namespace Application.Services.Contracts
{
    public interface IPostsService
    {
        public string CreatePost(Post post);

        public Post GetPostById(int id);
        
        public Post GetPostByCreatorUsername(string creatorUsername);

        public Post GetPostByReceiverUsername(string receiverUsername);
    }
}
