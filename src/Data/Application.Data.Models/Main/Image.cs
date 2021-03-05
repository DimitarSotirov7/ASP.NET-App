namespace Application.Models.Main
{
    using System;
    using System.Collections.Generic;

    using Application.Data.Common.Models;
    using Application.Data.Models.Main;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Likes = new HashSet<Like>();
            this.Dislikes = new HashSet<Dislike>();
            this.Comments = new HashSet<Comment>();
        }

        public string ImageUrl { get; set; }

        public string Extension { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Dislike> Dislikes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
