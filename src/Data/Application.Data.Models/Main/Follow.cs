namespace Application.Models.Main
{
    using Application.Data.Common.Models;
    using Application.Data.Models;

    public class Follow : BaseDeletableModel<int>
    {
        public string FromUserId { get; set; }

        public virtual ApplicationUser FromUser { get; set; }

        public string ToUserId { get; set; }

        public virtual ApplicationUser ToUser { get; set; }
    }
}
