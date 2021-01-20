using Application.Models.Common;

namespace Application.Models.UserStuffs
{
    public class Image : BaseModel
    {
        public string ImageUrl { get; set; }

        public byte?[] ImageFile { get; set; }
    }
}
