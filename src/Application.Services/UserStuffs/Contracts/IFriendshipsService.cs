using Application.Models;

namespace Application.Services.Contracts
{
    public interface IFriendshipsService
    {
        public bool CreateFriendship(string requesterId, string responderId);

        public bool AcceptFriendship(string requesterId, string responderId);

        public bool BlockFriendship(string requesterId, string responderId);

        public bool UnBlockFriendship(string requesterId, string responderId);

        public bool RemoveFriendship(string requesterId, string responderId);
    }
}
