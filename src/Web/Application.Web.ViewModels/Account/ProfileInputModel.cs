namespace Application.Web.ViewModels.Account
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;

    public class ProfileInputModel
    {
        public IEnumerable<IFormFile> LocalImages { get; set; }

        public string ImageUrl { get; set; }
    }
}
