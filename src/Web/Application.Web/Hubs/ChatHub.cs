namespace Application.Web.Hubs
{
    using System.Threading.Tasks;

    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated;
    using Application.Web.ViewModels.UserRelated.Chats;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessagesService messagesService;

        public ChatHub(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        public async Task Send(MessageInputModel input)
        {
            // save message in Db
            await this.messagesService.CreateMessageAsync(input);

            var lastMessage = this.messagesService
                .GetLastMessage<MessageViewModel>(input.FromUserId, input.ToUserId);

            string[] users = { input.FromUserId, input.ToUserId };

            // send message to users
            await this.Clients.Users(users).SendAsync("NewMessage", lastMessage);
        }
    }
}
