namespace Application.Web.ViewModels.UserRelated
{
    using System.ComponentModel.DataAnnotations;

    public class FriendshipInputModel
    {
        public string FromId { get; set; }

        [Required]
        public string ToId { get; set; }
    }
}
