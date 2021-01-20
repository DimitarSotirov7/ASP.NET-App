using Application.Models.Common;
using System.Collections.Generic;

namespace Application.Models.Q_A_Game
{
    public class Category : BaseModel
    {
        public Category()
        {
            this.Questions = new HashSet<Question>();
        }

        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
