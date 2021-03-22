namespace Application.Web.ViewModels.UserRelated.Chats
{
    using System.Collections.Generic;

    public class ChatsViewModel
    {
        public ICollection<ChatUserViewModel> Users { get; set; }

        public ICollection<AllMessagesViewModel> UserMessages { get; set; }
    }
}
