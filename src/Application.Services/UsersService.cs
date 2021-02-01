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

        public bool CreateUser(User user)
        {
            bool invalid = user == null ||
                (user.FirstName == null || user.Username == null || user.Password == null);

            if (invalid)
            {
                return false;
            }

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
            db.SaveChanges();

            return true;
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
    }
}
