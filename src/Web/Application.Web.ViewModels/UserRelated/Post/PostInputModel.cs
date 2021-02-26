namespace Application.Web.ViewModels.UserRelated
{
    using Application.Models.Main;
    using Application.Services.Mapping;
    using AutoMapper;

    public class PostInputModel : IMapTo<Post>
    {
        public string Content { get; set; }

        public string ImageId { get; set; }

        public string FromUserId { get; set; }

        public string ToUserId { get; set; }
    }
}
