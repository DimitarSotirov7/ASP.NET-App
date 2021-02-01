using Application.Models.UserStuffs;

namespace Application.Mapping.PostDTOModels
{
    public class GetPostDTO
    {
        public string Context { get; set; }

        public Image Image { get; set; }

        public int FromUserId { get; set; }

        public int? ToUserId { get; set; }

        public string PostOn { get; set; }

        public int LikesCount { get; set; }

        public int CommentsCount { get; set; }
    }
}
