using Application.Data;
using Application.Mapping.CategoryDTOModels;
using Application.Models.Q_A_Game;
using Application.Services.Q_A_Game.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Q_A_Game
{
    public class CategoriesService : ICategoriesService
    {
        private ApplicationDbContext db;
        private MapperConfiguration config;

        public CategoriesService(ApplicationDbContext db, MapperConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public ICollection<Question> GetAnsweredQuestionContextsByCategoryId(string id)
        {
            return db.UsersQuestions
                .Where(x => x.Question.CategoryId == id && x.User != null)
                .Select(x => x.Question)
                .ToList(); 
        }

        public string GetCategoryNameWithMostAnsweredQuestions()
        {
            return db.Categories
                .OrderByDescending(x => x.Questions.Count)
                .ProjectTo<CategoryNameDTO>(this.config)
                .Take(1).FirstOrDefault().Name;
        }
    }
}
