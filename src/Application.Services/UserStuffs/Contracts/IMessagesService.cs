using Application.Models.UserStuffs;
using System.Collections.Generic;

namespace Application.Services.Contracts
{
    public interface IMessagesService
    {
        public bool CreateMessage(Message message);

        public bool SetSeenMessageByUsers(int fromUserId, int toUserId);

        public ICollection<Message> GetMessagesByUserIds(int firstUserId, int secondUserId, int messagesCount);
    }
}
