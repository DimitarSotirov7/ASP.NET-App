using System.ComponentModel.DataAnnotations;

namespace Application.Web.ViewModels.UserRelated
{
    public class FriendshipInputModel
    {
        public string FromId { get; set; }

        [Required]
        public string ToId { get; set; }
    }
}
