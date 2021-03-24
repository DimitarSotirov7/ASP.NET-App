namespace Application.Web.ViewModels.Chat
{
    public class ChatViewModel
    {
        public string Content { get; set; }

        public string FromUserId { get; set; }

        public string FromUserName { get; set; }

        public string FromUserProfileImagePath { get; set; }

        public string ToUserId { get; set; }

        public string ToUserName { get; set; }

        public string ToUserProfileImagePath { get; set; }

        public string ImagePath { get; set; }

        public bool Seen { get; set; }
    }
}
