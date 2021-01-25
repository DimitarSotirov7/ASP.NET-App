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
        private const string SuccessfullMessage = "Done!";

        private ApplicationDbContext db;

        public QuestionsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateQuestion(Question question)
        {
            bool requireInfo = question != null && question.Context != null;

            if (!requireInfo)
            {
                return null;
            }

            db.Questions.Add(question);
            db.SaveChanges();

            return SuccessfullMessage;
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
