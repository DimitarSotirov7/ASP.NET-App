namespace Application.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Data.Models;
    using Application.Data.Models.Main;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class DummyUsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedRoleAsync(userManager);
        }

        private static async Task SeedRoleAsync(UserManager<ApplicationUser> userManager)
        {
            string firstEmail = "demo123@demo.com", secondEmail = "test123@test.com";

            var firstUser = await userManager.FindByEmailAsync(firstEmail);
            var secondUser = await userManager.FindByEmailAsync(secondEmail);
            if (firstUser == null && secondUser == null)
            {
                var user = new ApplicationUser
                {
                    Email = firstEmail,
                    UserName = firstEmail.Substring(0, 7),
                    PasswordHint = firstEmail.Substring(0, 7),
                    FirstName = firstEmail.Substring(0, 4),
                    LastName = firstEmail.Substring(0, 4) + "v",
                    Gender = GenderType.Male,
                    Address = new Address { City = "Sofia" },
                    DateOfBirth = new DateTime(2000, 1, 1),
                };
                var result = await userManager.CreateAsync(user, firstEmail.Substring(0, 7));

                user = new ApplicationUser
                {
                    Email = secondEmail,
                    UserName = secondEmail.Substring(0, 7),
                    PasswordHint = secondEmail.Substring(0, 7),
                    FirstName = secondEmail.Substring(0, 4),
                    LastName = secondEmail.Substring(0, 4) + "ova",
                    Gender = GenderType.Female,
                    Address = new Address { City = "Varna" },
                    DateOfBirth = new DateTime(2010, 1, 1),
                };

                result = await userManager.CreateAsync(user, secondEmail.Substring(0, 7));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
