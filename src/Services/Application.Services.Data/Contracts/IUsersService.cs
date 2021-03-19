namespace Application.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Data.Models.Main;
    using Application.Web.ViewModels.Account;
    using Microsoft.AspNetCore.Http;

    public interface IUsersService
    {
        public Task CreateUserAsync(RegisterInputModel input);

        public ProfileViewModel GetUserInformation(string userId);

        public int GetUsersCount();

        public UserImagesViewModel GetUserImages(string userId);

        public Task UploadUserImagesAsync(string userId, IEnumerable<IFormFile> localImages, string imageUrl, string userimagesPath);

        public string GetUserIdByUsernameAndPassword(string username, string password = null);

        public string GetUserUsernameById(string id);

        public ICollection<Friendship> GetAllFriendshipRequestsByUserId(string userId);

        public ICollection<Friendship> GetAllFriendshipResponsesByUserId(string userId);

        public T GetEmailUserInfo<T>(string userId);
    }
}
