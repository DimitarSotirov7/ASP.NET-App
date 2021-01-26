using Application.Models.UserStuffs;
using System.Collections.Generic;

namespace Application.Services.Contracts
{
    public interface IFollowsService
    {
        public bool CreateFollow(Follow follow);

        public ICollection<Follow> GetFollowingsByUserId(int userId);

        public ICollection<Follow> GetFollowersByUserId(int userId);
    }
}
