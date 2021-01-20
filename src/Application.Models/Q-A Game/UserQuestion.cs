namespace Application.Models.Q_A_Game
{
    public class UserQuestion
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
