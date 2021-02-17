using Application.Models.UserStuffs;
using System.Collections.Generic;

namespace Application.Services.Contracts
{
    public interface IMessagesService
    {
        public bool CreateMessage(Message message);

        public bool SetSeenMessageByUsers(string fromUserId, string toUserId);

        public ICollection<Message> GetMessagesByUserIds(string firstUserId, string secondUserId, int messagesCount);
    }
}
