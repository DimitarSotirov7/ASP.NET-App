using Application.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Q_A_Game
{
    public class Category : BaseModel
    {
        public Category()
        {
            this.Questions = new HashSet<Question>();
        }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
