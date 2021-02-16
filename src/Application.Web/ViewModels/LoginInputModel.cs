using System.ComponentModel.DataAnnotations;

namespace Application.Web.ViewModels
{
    public class LoginInputModel
    {
        [Required]
        [MinLength(6, ErrorMessage = "The username must be 6 characters min")]
        [MaxLength(50, ErrorMessage = "The username must be 50 characters max")]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "The password must be 6 characters min")]
        [MaxLength(50, ErrorMessage = "The password must be 50 characters max")]
        public string Password { get; set; }
    }
}
