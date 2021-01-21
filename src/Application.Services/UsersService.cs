using Application.Data;
using Application.Models;
using Application.Models.Q_A_Game;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using System;
using System.Collections.Generic;
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

        public ICollection<Comment> GetAllCommentsReceivedByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.CommentsReceived;
        }

        public ICollection<Follow> GetAllFollowersByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.Followers;
        }

        public ICollection<Follow> GetAllFollowingsByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.Followings;
        }

        public ICollection<Friendship> GetAllFriendshipRequestsByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.FriendshipRequests;
        }

        public ICollection<Friendship> GetAllFriendshipResponsesByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.FriendshipResponses;
        }

        public ICollection<Like> GetAllLikesReceivedByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.LikesReceived;
        }

        public ICollection<Message> GetAllMessagesReceivedByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.MessagesReceived;
        }

        public ICollection<Comment> GetAllOwnCommentsByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.OwnComments;
        }

        public ICollection<Like> GetAllOwnLikesByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.OwnLikes;
        }

        public ICollection<Message> GetAllOwnMessagesByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.OwnMessages;
        }

        public ICollection<Post> GetAllOwnPostsByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.OwnPosts;
        }

        public ICollection<Post> GetAllPostsReceivedByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.PostsReceived;
        }

        public ICollection<UserQuestion> GetAllQuestionByUserId(int userId)
        {
            var user = GetUserFromId(userId);

            if (user == null)
            {
                return null;
            }

            return user.Questions;
        }

        private User GetUserFromId(int userId)
        {
            return db.Users.FirstOrDefault(x => x.Id == userId);
        }
    }
}
