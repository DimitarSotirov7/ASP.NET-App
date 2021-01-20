using Application.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.UserStuffs
{
    public class Post : BaseModel
    {
        public Post()
        {
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        [Required, MaxLength(500)]
        public string Context { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }

        public int FromUserId { get; set; }
        public virtual User FromUser { get; set; }

        public int? ToUserId { get; set; }
        public virtual User ToUser { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
