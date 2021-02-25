namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Data.Common.Repositories;
    using Application.Models.Main;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated;

    public class MessagesService : IMessagesService
    {
        private readonly IDeletableEntityRepository<Message> messagesRepo;

        public MessagesService(IDeletableEntityRepository<Message> messagesRepo)
        {
            this.messagesRepo = messagesRepo;
        }

        public async Task CreateMessageAsync(MessageInputModel input)
        {
            var message = new Message()
            {
                Content = input.Content,
                FromUserId = input.FromUserId,
                ToUserId = input.ToUserId,
            };

            await this.messagesRepo.AddAsync(message);
            await this.messagesRepo.SaveChangesAsync();
        }

        public ICollection<Message> GetMessagesByUserIds(string firstUserId, string secondUserId, int messagesCount)
        {
            return this.messagesRepo.AllAsNoTracking()
                .Where(x => (x.FromUserId == firstUserId || x.FromUserId == secondUserId) &&
                 (x.ToUserId == firstUserId || x.ToUserId == secondUserId))
                .Take(messagesCount)
                .ToList();
        }

        public async Task<bool> SetSeenMessageByUsersAsync(MessageInputModel input)
        {
            var message = this.messagesRepo.AllAsNoTracking()
                .FirstOrDefault(x => x.FromUserId == input.FromUserId && x.ToUserId == input.ToUserId);

            if (message == null)
            {
                return false;
            }

            message.Seen = true;
            await this.messagesRepo.SaveChangesAsync();

            return true;
        }
    }
}
