namespace Application.Models.Films_Game
{
    public class UserFilmQuestion
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string FilmId { get; set; }
        public virtual Film Film { get; set; }

        public string QuestionId { get; set; }
        public virtual FilmQuestion Question { get; set; }

        public bool AnswerIsCorrect { get; set; }
    }
}
