﻿namespace Application.Data.Models.Main
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Application.Data.Common.Models;
    using Application.Data.Models;
    using Application.Data.Models.Main;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            this.Likes = new HashSet<Like>();
            this.Dislikes = new HashSet<Dislike>();
        }

        [MaxLength(250)]
        public string Content { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public string FromUserId { get; set; }

        public virtual ApplicationUser FromUser { get; set; }

        public int? ToPostId { get; set; }

        public virtual Post ToPost { get; set; }

        public string ToImageId { get; set; }

        public virtual Image ToImage { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Dislike> Dislikes { get; set; }
    }
}
