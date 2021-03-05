namespace Application.Web.ViewModels.UserRelated
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;

    using Application.Models.Main;
    using Application.Services.Mapping;

    public class PostInputModel
    {
        public PostInputModel()
        {
            this.LocalImages = new List<IFormFile>();
        }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<IFormFile> LocalImages { get; set; }

        public string FromUserId { get; set; }

        public string ToUserId { get; set; }
    }
}
