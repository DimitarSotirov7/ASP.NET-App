namespace Application.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Application.Web.ViewModels.UserRelated;

    public interface IMessagesService
    {
        public Task CreateMessageAsync(MessageInputModel input);

        public Task<bool> SetSeenMessageByUsersAsync(MessageInputModel input);

        public ICollection<T> GetMessagesByUserIds<T>(string firstUserId, string secondUserId, int messagesCount = 0);

        public T GetLastMessage<T>(string firstUserId, string secondUserId);
    }
}
