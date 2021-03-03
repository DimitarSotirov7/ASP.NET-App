namespace Application.Web.ViewModels.UserRelated
{
    using System;
    using System.Collections.Generic;

    public class AllLatestPostsViewModel : PagingViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}
