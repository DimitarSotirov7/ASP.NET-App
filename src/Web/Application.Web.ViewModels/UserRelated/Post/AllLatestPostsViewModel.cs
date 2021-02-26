namespace Application.Web.ViewModels.UserRelated
{
    using System;
    using System.Collections.Generic;

    public class AllLatestPostsViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }

        public int CurrentPage { get; set; }

        public int PostsPerPage { get; set; }

        public int PostsCount { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.PostsCount / this.PostsPerPage);

        public int PreviousPageNumber => this.CurrentPage - 1;

        public int NextPageNumber => this.CurrentPage + 1;

        public bool HasPreviousPage => this.CurrentPage > 1;

        public bool HasNextPage => this.CurrentPage < this.PagesCount;
    }
}
