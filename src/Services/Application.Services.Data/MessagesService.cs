namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Data.Common.Repositories;
    using Application.Data.Models.Main;
    using Application.Services.Contracts;
    using Application.Services.Mapping;
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

        public T GetLastMessage<T>(string firstUserId, string secondUserId)
        {
            return this.messagesRepo.AllAsNoTracking()
                 .Where(x => (x.FromUserId == firstUserId && x.ToUserId == secondUserId) ||
                     (x.FromUserId == secondUserId && x.ToUserId == firstUserId))
                 .OrderByDescending(x => x.CreatedOn)
                 .To<T>()
                 .FirstOrDefault();
        }

        public ICollection<T> GetMessagesByUserIds<T>(string firstUserId, string secondUserId, int messagesCount = 0)
        {
            int messages = 0;
            if (messagesCount == 0)
            {
                messages = this.messagesRepo.AllAsNoTracking()
                    .Where(x => (x.FromUserId == firstUserId && x.ToUserId == secondUserId) ||
                    (x.FromUserId == secondUserId && x.ToUserId == firstUserId))
                    .Count();
            }

            return this.messagesRepo.AllAsNoTracking()
                .Where(x => (x.FromUserId == firstUserId && x.ToUserId == secondUserId) ||
                 (x.FromUserId == secondUserId && x.ToUserId == firstUserId))
                .OrderBy(x => x.CreatedOn)
                .Take(messagesCount > 0 ? messagesCount : messages)
                .To<T>()
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
