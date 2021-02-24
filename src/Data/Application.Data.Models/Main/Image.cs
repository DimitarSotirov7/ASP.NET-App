namespace Application.Models.Main
{
    using System;
    using System.Collections.Generic;

    using Application.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
