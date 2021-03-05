namespace Application.Web.ViewModels.UserRelated.Posts
{
    using System;
    using System.Collections.Generic;

    public class AllLatestPostsViewModel : PagingViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }

        public string LoggedUserProfileImagePath { get; set; }
    }
}
