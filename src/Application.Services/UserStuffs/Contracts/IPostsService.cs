using Application.Models.UserStuffs;

namespace Application.Services.Contracts
{
    public interface IPostsService
    {
        public bool CreatePost(Post post);

        public Post GetPostById(int id);
        
        public Post GetPostByCreatorUsername(string creatorUsername);

        public Post GetPostByReceiverUsername(string receiverUsername);
    }
}
