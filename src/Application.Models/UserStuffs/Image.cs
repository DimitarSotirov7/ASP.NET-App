using Application.Models.Common;

namespace Application.Models
{
    public class Image : BaseModel
    {
        public string ImageUrl { get; set; }

        public byte[] ImageFile { get; set; }
    }
}
