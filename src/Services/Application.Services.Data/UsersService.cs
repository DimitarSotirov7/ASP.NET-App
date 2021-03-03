namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    using Application.Services.Mapping;
    using Application.Data.Common.Repositories;
    using Application.Data.Models;
    using Application.Models.Main;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.Account;
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using Application.Data.Common;

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

        public string GetUserIdByUsernameAndPassword(string username, string password = null)
        {
            if (password == null)
            {
                return this.usersRepo.AllAsNoTracking()
                    .FirstOrDefault(x => x.UserName == username).Id;
            }

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

        public string GetUserUsernameById(string id)
        {
            return this.usersRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == id).UserName;
        }

        public UserImagesViewModel GetUserImages(string userId)
        {
            var userImageId = this.usersRepo.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == userId).ProfileImageId;

            var userImages = this.usersRepo.AllAsNoTracking()
                .Where(x => x.Id == userId)
                .To<UserImagesViewModel>()
                .FirstOrDefault();

            if (userImageId == null)
            {
                userImages.ProfileImagePath = null;
            }

            return userImages;
        }

        public async Task UploadUserImagesAsync(string userId, IEnumerable<IFormFile> localImages, string imageUrl, string userimagesPath)
        {
            var user = this.usersRepo.All().Where(x => x.Id == userId);

            if (user == null)
            {
                return;
            }

            if (imageUrl != null)
            {
                user.FirstOrDefault().OtherImages.Add(new Image { ImageUrl = imageUrl });
            }

            Directory.CreateDirectory(userimagesPath);
            foreach (var localImage in localImages)
            {
                var imageExtension = Path.GetExtension(localImage.FileName).TrimStart('.');

                // TODO: throw exseption if extension is not valid
                if (!GlobalConstants.AllowedImageExtensions.Contains(imageExtension))
                {
                    continue;
                }

                // Create image in post
                var image = new Image
                {
                    Extension = imageExtension,
                };

                user.FirstOrDefault().OtherImages.Add(image);

                // Save physically
                var fileDirectoty = $"{userimagesPath}/{image.Id}.{image.Extension}";
                using (Stream fileStream = new FileStream(fileDirectoty, FileMode.Create))
                {
                    await localImage.CopyToAsync(fileStream);
                }
            }

            await this.usersRepo.SaveChangesAsync();
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
                {
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                }

                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
