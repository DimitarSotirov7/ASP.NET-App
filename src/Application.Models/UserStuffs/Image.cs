using Application.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.UserStuffs
{
    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UploadedOn = DateTime.UtcNow;

            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        public DateTime UploadedOn { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
