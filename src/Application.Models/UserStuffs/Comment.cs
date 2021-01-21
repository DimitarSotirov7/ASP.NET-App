using Application.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.UserStuffs
{
    public class Comment : BaseModel
    {
        [Required, MaxLength(250)]
        public string Context { get; set; }

        public int FromUserId { get; set; }
        public virtual User FromUser { get; set; }

        public int ToUserId { get; set; }
        public virtual User ToUser { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }

        public virtual DateTime CommentedOn { get; set; }
    }
}
