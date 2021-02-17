using Application.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Films_Game
{
    public class FilmAnswer : BaseModel<string>
    {
        public FilmAnswer()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required, MaxLength(250)]
        public string Context { get; set; }

        public int QuestionId { get; set; }
        public virtual FilmQuestion Question { get; set; }

        public bool IsCorrect { get; set; }
    }
}
