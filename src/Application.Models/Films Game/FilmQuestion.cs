using Application.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Films_Game
{
    public class FilmQuestion : BaseModel
    {
        public FilmQuestion()
        {
            this.Answers = new HashSet<FilmAnswer>();
        }

        [Required, MaxLength(250)]
        public string Context { get; set; }

        public virtual ICollection<FilmAnswer> Answers { get; set; }
    }
}
