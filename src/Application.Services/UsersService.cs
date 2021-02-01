using Application.Data;
using Application.Models;
using Application.Models.Q_A_Game;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Application.Mapping.UserDTOModels;
using AutoMapper;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsersService : IUsersService
    {
        private const string DefaultProfileImage = "https://thumbs.dreamstime.com/b/default-avatar-profile-image-vector-social-media-user-icon-potrait-182347582.jpg";
        private const string DefaultCoverImage = "https://www.proactivechannel.com/Files/BrandImages/Default.jpg";

        private ApplicationDbContext db;
        private MapperConfiguration config;

        public UsersService(ApplicationDbContext db, MapperConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public async Task CreateUser(User user)
        {
            user.Password = Hash(user.Password);

            user.ProfileImage = user.ProfileImage ?? new Image 
            {
                ImageUrl = DefaultProfileImage,
                UploadedOn = DateTime.UtcNow
            };

            user.CoverImage = user.CoverImage ?? new Image
            {
                ImageUrl = DefaultCoverImage,
                UploadedOn = DateTime.UtcNow
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();
        }

        public GetUserDTO GetUserById(int userId)
        {
            return db.Users.Where(x => x.Id == userId).ProjectTo<GetUserDTO>(this.config).FirstOrDefault();
        }

        public int GetUserIdByUsername(string username)
        {
            return db.Users
                .Where(x => x.Username == username)
                .ProjectTo<GetUserIdDTO>(this.config)
                .FirstOrDefault().Id;
        }

        public ICollection<Friendship> GetAllFriendshipRequestsByUserId(int userId)
        {
            var user = db.Users.Find(userId);

            if (user == null)
            {
                return null;
            }

            return user.FriendshipRequests;
        }

        public ICollection<Friendship> GetAllFriendshipResponsesByUserId(int userId)
        {
            var user = db.Users.Find(userId);

            if (user == null)
            {
                return null;
            }

            return user.FriendshipResponses;
        }

        public ICollection<UserQuestion> GetAllQuestionByUserId(int userId)
        {
            var user = db.Users.Find(userId);

            if (user == null)
            {
                return null;
            }

            return user.Questions;
        }

        public bool IsUserValid(string username, string password)
        {
            return db.Users.Any(x => x.Username == username && x.Password == Hash(password));
        }

        public bool IsUsernameAvaliable(string username)
        {
            return db.Users.All(x => x.Username != username);
        }

        public bool IsEmailAvaliable(string email)
        {
            return db.Users.All(x => x.Email != email);
        }

        private static string Hash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
