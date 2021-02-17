using Application.Mapping.UserDTOModels;
using Application.Models;
using Application.Models.Q_A_Game;
using Application.Models.UserStuffs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
    public interface IUsersService
    {
        public Task CreateUserAsync(string email, string username, string password, string passwordHint, string firstName, string lastName, DateTime dateOfBirth);

        public int GetUsersCount();

        public int GetUserIdByUsername(string username);

        public GetUserDTO GetUserById(string userId);
        
        public ICollection<UserQuestion> GetAllQuestionByUserId(string id);

        public ICollection<Friendship> GetAllFriendshipRequestsByUserId(string userId);

        public ICollection<Friendship> GetAllFriendshipResponsesByUserId(string userId);

        public bool IsUserValid(string username, string password);

        public bool IsUsernameAvaliable(string username);
        
        public bool IsEmailAvaliable(string email);
    }
}
