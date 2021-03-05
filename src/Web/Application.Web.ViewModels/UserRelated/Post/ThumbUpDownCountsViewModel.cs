using Application.Services.Mapping;

namespace Application.Web.ViewModels.UserRelated.Post
{
    public class ThumbUpDownCountsViewModel : IMapFrom<Application.Models.Main.Post>
    {
        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }
    }
}
