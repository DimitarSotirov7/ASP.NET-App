using Application.Data;
using Application.Models.Q_A_Game;
using Application.Services.Q_A_Game.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Q_A_Game
{
    public class CategoriesService : ICategoriesService
    {
        private ApplicationDbContext db;

        public CategoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<Question> GetAllAnsweredQuestionsByCategoryId(int id)
        {
            return db.UsersQuestions
                .Where(x => x.Question.CategoryId == id)
                .Select(x => x.Question)
                .ToList(); 
        }

        public Category GetCategoryWithMostAnsweredQuestions()
        {
            return db.Categories
                .OrderByDescending(x => x.Questions.Count)
                .FirstOrDefault();
        }
    }
}
