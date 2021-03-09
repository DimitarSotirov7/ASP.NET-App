namespace Application.Web.ViewModels.UserRelated.Posts
{
    using Application.Data.Models.Main;
    using Application.Services.Mapping;

    public class ThumbUpDownCountsViewModel : IMapFrom<Post>
    {
        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }
    }
}
