namespace Application.Web.Controllers.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : Controller
    {
        private readonly IUsersService usersService;

        public UserController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Images()
        {
            return this.View();
        }
    }
}
