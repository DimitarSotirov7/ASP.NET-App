namespace Application.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Application.Data.Models.Main;
    using Application.Web.ViewModels.UserRelated;

    public interface IMessagesService
    {
        public Task CreateMessageAsync(MessageInputModel input);

        public Task<bool> SetSeenMessageByUsersAsync(MessageInputModel input);

        public ICollection<Message> GetMessagesByUserIds(string firstUserId, string secondUserId, int messagesCount);
    }
}
