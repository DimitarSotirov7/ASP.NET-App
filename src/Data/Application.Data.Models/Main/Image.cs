namespace Application.Data.Models.Main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Application.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Likes = new HashSet<Like>();
            this.Dislikes = new HashSet<Dislike>();
            this.ToImageComments = new HashSet<Comment>();
            this.ImageComments = new HashSet<Comment>();
        }

        public string ImageUrl { get; set; }

        public string Extension { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Dislike> Dislikes { get; set; }

        [InverseProperty("ToImage")]
        public virtual ICollection<Comment> ToImageComments { get; set; }

        [InverseProperty("Image")]
        public virtual ICollection<Comment> ImageComments { get; set; }
    }
}
