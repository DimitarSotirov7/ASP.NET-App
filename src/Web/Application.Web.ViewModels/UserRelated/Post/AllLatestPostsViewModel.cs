namespace Application.Web.ViewModels.UserRelated
{
    using System.Collections.Generic;

    public class AllLatestPostsViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}
