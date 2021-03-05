namespace Application.Web.ViewModels.UserRelated.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel
    {
        [MaxLength(250)]
        public string Content { get; set; }

        public string FromUserId { get; set; }

        public int? ToPostId { get; set; }

        public string ToImageId { get; set; }
    }
}
