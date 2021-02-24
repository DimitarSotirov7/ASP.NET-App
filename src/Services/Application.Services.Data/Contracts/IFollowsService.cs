namespace Application.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Models.Main;
    using Application.Web.ViewModels.UserRelated;

    public interface IFollowsService
    {
        public Task CreateFollowAsync(FollowInputModel input);

        //public ICollection<Follow> GetFollowingsByUserId(string userId);

        //public ICollection<Follow> GetFollowersByUserId(string userId);
    }
}
