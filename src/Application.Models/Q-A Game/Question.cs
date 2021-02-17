using Application.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Q_A_Game
{
    public class Question : BaseModel<string>
    {
        public Question()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Users = new HashSet<UserQuestion>();
        }

        [Required, MaxLength(250)]
        public string Context { get; set; }

        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<UserQuestion> Users { get; set; }
    }
}
