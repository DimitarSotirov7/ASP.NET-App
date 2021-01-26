namespace Application.Services.Q_A_Game.Contracts
{
    public interface IUsersQuestionsService
    {
        public bool CreateUserQuestion(int userId, int questionId, bool answer);
    }
}
