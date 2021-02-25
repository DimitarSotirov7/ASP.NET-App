namespace Application.Web.ViewModels.UserRelated
{
    using System.ComponentModel.DataAnnotations;

    public class PostInputModel
    {
        public string Content { get; set; }

        public string ImageId { get; set; }

        public string FromUserId { get; set; }

        public string ToUserName { get; set; }
    }
}
