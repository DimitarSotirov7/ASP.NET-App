using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.UserStuffs
{
    public class Friendship
    {
        public string RequesterId { get; set; }
        public virtual User Requester { get; set; }

        public string ResponderId { get; set; }
        public virtual User Responder { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsBlocked { get; set; }

        public string BlockedById { get; set; }
        public virtual User BlockedBy { get; set; }
    }
}
