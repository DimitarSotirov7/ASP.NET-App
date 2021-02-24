namespace Application.Models.Main
{
    using Application.Data.Common.Models;
    using Application.Data.Models;

    public class Friendship : BaseModel<int>
    {
        public string RequesterId { get; set; }

        public virtual ApplicationUser Requester { get; set; }

        public string ResponderId { get; set; }

        public virtual ApplicationUser Responder { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsBlocked { get; set; }

        public string BlockedById { get; set; }

        public virtual ApplicationUser BlockedBy { get; set; }
    }
}
