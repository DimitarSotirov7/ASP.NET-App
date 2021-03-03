namespace Application.Web.ViewModels.UserRelated
{
    using Application.Models.Main;
    using Application.Services.Mapping;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;

    public class PostInputModel : IMapTo<Post>
    {
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<IFormFile> LocalImages { get; set; }

        public string FromUserId { get; set; }

        public string ToUserId { get; set; }
    }
}
