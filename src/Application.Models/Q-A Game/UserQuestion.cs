namespace Application.Models.Q_A_Game
{
    public class UserQuestion
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public bool Answer { get; set; }
    }
}
