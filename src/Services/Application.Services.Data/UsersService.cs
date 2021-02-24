namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    using Application.Data.Common.Repositories;
    using Application.Data.Models;
    using Application.Models.Main;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.Account;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepo;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepo)
        {
            this.usersRepo = usersRepo;
        }

        public async Task CreateUserAsync(RegisterInputModel input)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = input.Email,
                UserName = input.Username,
                PasswordHash = input.Password,
                PasswordHint = input.PasswordHint,
                FirstName = input.FirstName,
                LastName = input.LastName,
                DateOfBirth = input.DateOfBirth,
            };

            await this.usersRepo.AddAsync(user);
            await this.usersRepo.SaveChangesAsync();
        }

        public string GetUserIdByUsernameAndPassword(string username, string password)
        {
            return this.usersRepo.AllAsNoTracking()
                .FirstOrDefault(x => x.UserName == username && x.PasswordHash == Hash(password)).Id;
        }

        public ICollection<Friendship> GetAllFriendshipRequestsByUserId(string userId)
        {
            var user = this.usersRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return null;
            }

            return user.FriendshipRequests;
        }

        public ICollection<Friendship> GetAllFriendshipResponsesByUserId(string userId)
        {
            var user = this.usersRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return null;
            }

            return user.FriendshipResponses;
        }

        public int GetUsersCount()
        {
            return this.usersRepo.AllAsNoTracking().Count();
        }

        private static string Hash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
