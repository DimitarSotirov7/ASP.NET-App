namespace Application.Models.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Application.Data.Common.Models;
    using Application.Data.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public string FromUserId { get; set; }

        public virtual ApplicationUser FromUser { get; set; }

        public string ToUserId { get; set; }

        public virtual ApplicationUser ToUser { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
