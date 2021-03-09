namespace Application.Web.ViewModels
{
    using Application.Data.Models.Main;
    using Application.Services.Mapping;

    public class ImagesViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Extension { get; set; }
    }
}
