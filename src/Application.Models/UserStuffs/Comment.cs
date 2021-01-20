using Application.Models.Common;

namespace Application.Models
{
    public class Comment : BaseModel
    {
        public string Context { get; set; }

        public int FromUserId { get; set; }
        public virtual User FromUser { get; set; }

        public int ToUserId { get; set; }
        public virtual User ToUser { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
