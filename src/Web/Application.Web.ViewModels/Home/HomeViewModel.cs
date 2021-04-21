namespace Application.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using Application.Web.ViewModels.UserRelated;

    public class HomeViewModel
    {
        public ICollection<UsersViewModel> AllUsers { get; set; }
    }
}
