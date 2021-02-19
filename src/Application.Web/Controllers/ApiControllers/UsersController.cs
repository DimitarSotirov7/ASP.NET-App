
using Application.Services.Contracts;
using Application.Web.ViewModels.ApiViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Application.Web.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IEnumerable<ApiUsersViewModel> Get()
        {
            var users = this.usersService.GetAllUsers()
                .Select(x => new ApiUsersViewModel 
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth.ToShortDateString(),
                    Joined = x.Joined.ToShortDateString(),
                    Username = x.Username,
                    Email = x.Email
                }).ToList();

            return users;
        }
    }
}
