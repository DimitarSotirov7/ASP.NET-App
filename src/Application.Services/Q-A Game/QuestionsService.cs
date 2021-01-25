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
            bool requireInfo = question != null && question.Context != null;

            if (!requireInfo)
            {
                return false;
            }

            db.Questions.Add(question);
            db.SaveChanges();

            return true;
        }

        public Question GetQuestionById(int id)
        {
            return db.Questions.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<UserQuestion> GetUsersByQuestionId(int id)
        {
            return db.Questions.FirstOrDefault(x => x.Id == id).Users;
        }
    }
}
