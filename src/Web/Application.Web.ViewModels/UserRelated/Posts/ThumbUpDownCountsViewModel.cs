namespace Application.Web.ViewModels.UserRelated.Posts
{
    using Application.Services.Mapping;

    public class ThumbUpDownCountsViewModel : IMapFrom<Application.Models.Main.Post>
    {
        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }
    }
}
