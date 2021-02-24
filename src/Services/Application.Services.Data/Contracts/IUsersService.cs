namespace Application.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Application.Models.Main;
    using Application.Web.ViewModels.Account;

    public interface IUsersService
    {
        public Task CreateUserAsync(RegisterInputModel input);

        public int GetUsersCount();

        public string GetUserIdByUsernameAndPassword(string username, string password);

        public ICollection<Friendship> GetAllFriendshipRequestsByUserId(string userId);

        public ICollection<Friendship> GetAllFriendshipResponsesByUserId(string userId);
    }
}
