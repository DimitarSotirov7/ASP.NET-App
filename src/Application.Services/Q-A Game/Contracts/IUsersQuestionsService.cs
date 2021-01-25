namespace Application.Services.Q_A_Game.Contracts
{
    public interface IUsersQuestionsService
    {
        public string CreateUserQuestion(int userId, int questionId, bool isCorrect);

        public bool GetAnswerByUserAndQuestionId(int userId, int questionId);
    }
}
