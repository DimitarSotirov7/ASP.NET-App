using Application.Models.UserStuffs;

namespace Application.Services.Contracts
{
    public interface IMessagesService
    {
        public string CreateMessage(Message message);

        public string SetSeenMessageById(int id);

        public Message GetMessageById(int id);

        public Message GetMessageByCreatorUsername(string creatorUsername);

        public Message GetMessageByReceiverUsername(string receiverUsername);
    }
}
