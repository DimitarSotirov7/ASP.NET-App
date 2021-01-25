using Application.Models;

namespace Application.Services.Contracts
{
    public interface IFriendshipsService
    {
        public string CreateFriendship(int requesterId, int responderId);

        public string AcceptFriendship(int requesterId, int responderId);

        public string RemoveFriendship(int requesterId, int responderId);
    }
}
