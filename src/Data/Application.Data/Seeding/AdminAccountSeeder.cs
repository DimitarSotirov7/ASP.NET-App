namespace Application.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Common;
    using Application.Data.Models;
    using Application.Data.Models.Main;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class AdminAccountSeeder : ISeeder
    {
        private readonly AdminCredentials adminCredentials;

        public AdminAccountSeeder(AdminCredentials adminCredentials)
        {
            this.adminCredentials = adminCredentials;
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedRoleAsync(userManager, this.adminCredentials);
        }

        private static async Task SeedRoleAsync(UserManager<ApplicationUser> userManager, AdminCredentials adminCredentials)
        {
            var user = await userManager.FindByEmailAsync(adminCredentials.Email);
            if (user == null)
            {
                var admin = new ApplicationUser
                {
                    Email = adminCredentials.Email,
                    UserName = adminCredentials.Username,
                    PasswordHint = "personal",
                    FirstName = "Dimitar",
                    LastName = "Sotirov",
                    Gender = GenderType.Male,
                    Address = new Address { City = "Sofia" },
                    DateOfBirth = new DateTime(1993, 5, 5, 9, 50, 0),
                };

                var result = await userManager.CreateAsync(admin, adminCredentials.Password);
                await userManager.AddToRoleAsync(admin, "Administrator");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
