using Application.Models.Common;

namespace Application.Models.UserStuffs
{
    public class Like : BaseModel
    {
        public int FromUserId { get; set; }
        public virtual User FromUser { get; set; }

        public int ToUserId { get; set; }
        public virtual User ToUser { get; set; }
    }
}
