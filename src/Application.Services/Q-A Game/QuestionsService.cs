using Application.Data;
using Application.Models;
using Application.Models.Q_A_Game;
using Application.Services.Q_A_Game.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Q_A_Game
{
    public class QuestionsService : IQuestionsService
    {
        private ApplicationDbContext db;

        public QuestionsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool CreateQuestion(Question question)
        {
            var category = db.Categories.Find(question.CategoryId);
            if (question == null || question.Context == null || category == null)
            {
                return false;
            }

            db.Questions.Add(question);
            db.SaveChanges();

            return true;
        }

        public ICollection<string> GetQuestionContextsByCategoryId(int id)
        {
            return db.Questions
                .Where(x => x.CategoryId == id)
                .Select(x => x.Context)
                .ToList();
        }
    }
}
