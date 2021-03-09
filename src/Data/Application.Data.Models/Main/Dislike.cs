namespace Application.Data.Models.Main
{
    using Application.Data.Common.Models;

    public class Dislike : BaseModel<int>
    {
        public string FromUserId { get; set; }

        public virtual ApplicationUser FromUser { get; set; }

        public int? ToCommentId { get; set; }

        public virtual Comment ToComment { get; set; }

        public string ToImageId { get; set; }

        public virtual Image ToImage { get; set; }

        public int? ToMessageId { get; set; }

        public virtual Message ToMessage { get; set; }

        public int? ToPostId { get; set; }

        public virtual Post ToPost { get; set; }
    }
}
