﻿using Application.Data;
using Application.Models.Q_A_Game;
using Application.Services.Q_A_Game.Contracts;
using System.Linq;

namespace Application.Services.Q_A_Game
{
    public class UsersQuestionsService : IUsersQuestionsService
    {
        private ApplicationDbContext db;

        public UsersQuestionsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool CreateUserQuestion(int userId, int questionId, bool isCorrect)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == userId);
            var question = db.Questions.FirstOrDefault(x => x.Id == questionId);

            if (user == null || question == null)
            {
                return false;
            }

            var userQuestion = new UserQuestion 
            {
                UserId = userId,
                QuestionId = questionId,
                IsCorrect = isCorrect
            };

            db.UsersQuestions.Add(userQuestion);
            db.SaveChanges();

            return true;
        }

        public bool GetAnswerByUserAndQuestionId(int userId, int questionId)
        {
            return db.UsersQuestions
                .FirstOrDefault(x => x.UserId == userId && x.QuestionId == questionId).IsCorrect;
        }
    }
}
