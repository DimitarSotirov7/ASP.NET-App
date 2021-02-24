namespace Application.Services
{
    using Application.Data.Common.Repositories;
    using Application.Models.Main;
    using Application.Services.Contracts;
    using Application.Web.ViewModels.UserRelated;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FollowsService : IFollowsService
    {
        private readonly IDeletableEntityRepository<Follow> followsRepo;

        public FollowsService(IDeletableEntityRepository<Follow> followsRepo)
        {
            this.followsRepo = followsRepo;
        }

        public async Task CreateFollowAsync(FollowInputModel input)
        {
            var follow = new Follow()
            {
                FromUserId = input.FromUserId,
                ToUserId = input.ToUserId,
            };

            await this.followsRepo.AddAsync(follow);
            await this.followsRepo.SaveChangesAsync();
        }

        //public ICollection<Follow> GetFollowersByUserId(string userId)
        //{
        //}

        //public ICollection<Follow> GetFollowingsByUserId(string userId)
        //{
        //}
    }
}
