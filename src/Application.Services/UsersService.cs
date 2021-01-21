using Application.Data;
using Application.Models;
using Application.Services.Contracts;
using System;
using System.Linq;

namespace Application.Services
{
    public class UsersService : IUsersService
    {
        private const string SuccessfullMessage = "Done!";

        private ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateUser(User user)
        {
            bool requiredInfo = user != null &&
                user.FirstName != null &&
                user.Username != null &&
                user.Password != null;

            if (!requiredInfo)
            {
                return null;
            }

            User userToCreate = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName ?? null,
                DateOfBirth = user.DateOfBirth ?? null,
                Joined = DateTime.Now,
                Username = user.Username,
                Password = user.Password,
                PasswordHint = user.PasswordHint ?? null,
                ImageId = user.ImageId ?? null
            };

            db.Users.Add(userToCreate);
            db.SaveChanges();

            return SuccessfullMessage;
        }

        public User GetUserById(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return db.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
