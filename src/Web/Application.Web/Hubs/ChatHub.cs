using Application.Data.Models.Main;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Application.Web.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessagesService messagesService;
        private readonly IUsersService usersService;

        public ChatHub(IMessagesService messagesService, IUsersService usersService)
        {
            this.messagesService = messagesService;
            this.usersService = usersService;
        }

        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("NewMessage", new Message
            {
                Content = message,
            });
        }
    }
}
