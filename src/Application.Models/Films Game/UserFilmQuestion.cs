namespace Application.Models.Films_Game
{
    public class UserFilmQuestion
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int FilmId { get; set; }
        public virtual Film Film { get; set; }

        public int QuestionId { get; set; }
        public virtual FilmQuestion Question { get; set; }

        public bool AnswerIsCorrect { get; set; }
    }
}
