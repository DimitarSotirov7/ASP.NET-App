namespace Application.Web.ViewModels.UserRelated.Chats
{
    using System.Collections.Generic;
    using System.Linq;

    public class AllMessagesViewModel
    {
        public ICollection<MessageViewModel> Messages { get; set; }

        public string LoggedUserId { get; set; }

        public MessageViewModel LastMessage =>
            this.Messages.OrderByDescending(x => x.CreatedOn).FirstOrDefault();
    }
}
