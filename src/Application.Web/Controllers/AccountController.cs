﻿using Application.Services.Contracts;
using Application.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Application.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService usersService;

        public AccountController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            bool validUser = this.usersService.IsUserValid(input.Username, input.Password);

            if (!validUser)
            {
                return this.View();
            }

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.usersService
                .CreateUser(input.Email, input.Username, input.Password, input.PasswordHint, input.FirstName, input.LastName, input.DateOfBirth);

            return this.Redirect("/Account/Login");
        }
    }
}