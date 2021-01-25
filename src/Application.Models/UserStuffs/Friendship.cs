using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.UserStuffs
{
    public class Friendship
    {
        public int RequesterId { get; set; }
        public virtual User Requester { get; set; }

        public int ResponderId { get; set; }
        public virtual User Responder { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsBlocked { get; set; }
    }
}
