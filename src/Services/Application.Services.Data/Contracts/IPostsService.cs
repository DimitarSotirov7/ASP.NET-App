﻿namespace Application.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Application.Models.Main;
    using Application.Web.ViewModels.UserRelated;

    public interface IPostsService
    {
        public Task CreatePostAsync(PostInputModel input);

        public ICollection<Post> GetAllLatestPosts(int count);
    }
}
