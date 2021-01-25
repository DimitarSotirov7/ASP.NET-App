using Application.Models;
using Application.Models.Q_A_Game;
using System.Collections.Generic;

namespace Application.Services.Q_A_Game.Contracts
{
    public interface IQuestionsService
    {
        public bool CreateQuestion(Question question);

        public Question GetQuestionById(int id);

        public ICollection<UserQuestion> GetUsersByQuestionId(int id);
    }
}
