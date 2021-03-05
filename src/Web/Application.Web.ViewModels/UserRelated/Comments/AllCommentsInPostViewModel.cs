namespace Application.Web.ViewModels.UserRelated.Comments
{
    using System.Collections.Generic;

    using Application.Models.Main;
    using Application.Services.Mapping;

    public class AllCommentsInPostViewModel : IMapFrom<Post>
    {
        public AllCommentsInPostViewModel()
        {
            this.Comments = new HashSet<CommentViewModel>();
        }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
