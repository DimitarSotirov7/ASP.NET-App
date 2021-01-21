using Application.Models;
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
    }
}
