namespace Application.Web.ViewModels.UserRelated
{
    public class LikeInputModel
    {
        public string FromUserId { get; set; }

        public int? ToCommentId { get; set; }

        public string ToImageId { get; set; }

        public int? ToMessageId { get; set; }

        public int? ToPostId { get; set; }
    }
}
