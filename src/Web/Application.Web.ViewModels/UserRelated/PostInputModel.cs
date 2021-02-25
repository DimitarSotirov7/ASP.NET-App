using System.ComponentModel.DataAnnotations;

namespace Application.Web.ViewModels.UserRelated
{
    public class PostInputModel
    {
        public string Content { get; set; }

        public string ImageId { get; set; }

        [Required]
        public string FromUserId { get; set; }

        public string ToUserId { get; set; }
    }
}
