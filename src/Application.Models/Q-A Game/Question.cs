using Application.Models.Common;
using System.Collections.Generic;

namespace Application.Models.Q_A_Game
{
    public class Question : BaseModel
    {
        public Question()
        {
            this.Users = new HashSet<UserQuestion>();
        }

        public string Context { get; set; }

        public bool IsCorrect { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<UserQuestion> Users { get; set; }
    }
}
