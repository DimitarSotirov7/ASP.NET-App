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
            input.FromUserId = this.Context.UserIdentifier;
            await this.messagesService.CreateMessageAsync(input);
            var lastMessage = this.messagesService
                .GetLastMessage<MessageViewModel>(input.FromUserId, input.ToUserId);
            lastMessage.LoggedUser = input.FromUserId;

            string[] users = { input.FromUserId, input.ToUserId };

            await this.Clients.Users(users).SendAsync("NewMessage", lastMessage);
        }
    }
}
