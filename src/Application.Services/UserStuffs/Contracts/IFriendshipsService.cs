using Application.Models;

namespace Application.Services.Contracts
{
    public interface IFriendshipsService
    {
        public bool CreateFriendship(int requesterId, int responderId);

        public bool AcceptFriendship(int requesterId, int responderId);

        public bool RemoveFriendship(int requesterId, int responderId);
    }
}
