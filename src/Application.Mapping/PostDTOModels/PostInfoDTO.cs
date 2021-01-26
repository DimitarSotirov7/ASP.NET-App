namespace Application.Mapping.PostDTOModels
{
    public class PostInfoDTO
    {
        public string Context { get; set; }

        public string ImageUrl { get; set; }

        public byte[] ImageFile { get; set; }

        public int FromUserId { get; set; }

        public int? ToUserId { get; set; }

        public string PostOn { get; set; }

        public int LikesCount { get; set; }

        public int CommentsCount { get; set; }
    }
}
