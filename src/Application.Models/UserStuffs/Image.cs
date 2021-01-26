using Application.Models.Common;
using System;
using System.Collections.Generic;

namespace Application.Models.UserStuffs
{
    public class Image : BaseModel
    {
        public Image()
        {
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        public string ImageUrl { get; set; }

        public byte[] ImageFile { get; set; }

        public DateTime UploadedOn { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
