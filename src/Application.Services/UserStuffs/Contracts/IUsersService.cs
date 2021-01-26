using Application.Mapping.UserDTOModels;
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
        public bool CreateUser(User user);

        public int GetUserIdByUsername(string username);

        public string GetUserFullNameById(int id);

        public UserInfoDTO GetUserInfoById(int id);

        public UserImagesDTO GetUserImagesById(int id);

        public UserAuthDTO GetUserAuthenticationById(int id);
        
        public ICollection<UserQuestion> GetAllQuestionByUserId(int id);

        public ICollection<Friendship> GetAllFriendshipRequestsByUserId(int userId);
        public ICollection<Friendship> GetAllFriendshipResponsesByUserId(int userId);
    }
}
