﻿namespace Application.Data.Models.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Application.Data.Common.Models;
    using Application.Data.Models;
    using Application.Data.Models.Main;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Likes = new HashSet<Like>();
            this.Dislikes = new HashSet<Dislike>();
            this.Comments = new HashSet<Comment>();
            this.Images = new HashSet<Image>();
        }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public string FromUserId { get; set; }

        public virtual ApplicationUser FromUser { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Dislike> Dislikes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
