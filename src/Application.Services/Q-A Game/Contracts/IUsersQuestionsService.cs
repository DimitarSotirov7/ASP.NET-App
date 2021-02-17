namespace Application.Services.Q_A_Game.Contracts
{
    public interface IUsersQuestionsService
    {
        public bool CreateUserQuestion(string userId, string questionId, bool answer);
    }
}
