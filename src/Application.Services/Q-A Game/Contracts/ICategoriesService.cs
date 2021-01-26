using Application.Models.Q_A_Game;
using System.Collections.Generic;

namespace Application.Services.Q_A_Game.Contracts
{
    public interface ICategoriesService
    {
        public ICollection<Question> GetAnsweredQuestionContextsByCategoryId(int id);

        public string GetCategoryNameWithMostAnsweredQuestions();
    }
}
