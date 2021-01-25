using Application.Models;
using Application.Models.Q_A_Game;
using Application.Models.UserStuffs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Contracts
{
    public interface IUsersService
    {
        public User GetUserByUsername(string username);

        public User GetUserById(int id);

        public string CreateUser(User user);

        public ICollection<Message> GetAllOwnMessagesByUserId(int userId);
        public ICollection<Message> GetAllMessagesReceivedByUserId(int userId);

        public ICollection<Follow> GetAllFollowingsByUserId(int userId);
        public ICollection<Follow> GetAllFollowersByUserId(int userId);

        public ICollection<Post> GetAllOwnPostsByUserId(int userId);
        public ICollection<Post> GetAllPostsReceivedByUserId(int userId);

        public ICollection<Like> GetAllOwnLikesByUserId(int userId);
        public ICollection<Like> GetAllLikesReceivedByUserId(int userId);

        public ICollection<Comment> GetAllOwnCommentsByUserId(int userId);
        public ICollection<Comment> GetAllCommentsReceivedByUserId(int userId);

        public ICollection<UserQuestion> GetAllQuestionByUserId(int userId);

        public ICollection<Friendship> GetAllFriendshipRequestsByUserId(int userId);
        public ICollection<Friendship> GetAllFriendshipResponsesByUserId(int userId);
    }
}
