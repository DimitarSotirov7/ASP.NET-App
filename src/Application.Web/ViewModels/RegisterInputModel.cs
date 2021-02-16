using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Web.ViewModels
{
    public class RegisterInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "The username must be 6 characters min")]
        [MaxLength(50, ErrorMessage = "The username must be 50 characters max")]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "The password must be 6 characters min")]
        [MaxLength(50, ErrorMessage = "The password must be 50 characters max")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required]
        [Compare("Password", ErrorMessage = "The Password and Confirm password fields do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Password hint")]
        [MaxLength(50, ErrorMessage = "The Password hint must be 50 characters max")]
        public string PasswordHint { get; set; }

        [Display(Name = "First name")]
        [Required]
        [MinLength(2, ErrorMessage = "The first name must be 2 characters min")]
        [MaxLength(50, ErrorMessage = "The first name must be 50 characters max")]
        [RegularExpression("[A-Z][a-z]+", ErrorMessage = "The first name should start with upper letter")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        [MinLength(2, ErrorMessage = "The last name must be 2 characters min")]
        [MaxLength(50, ErrorMessage = "The last name must be 50 characters max")]
        [RegularExpression("[A-Z][a-z]+", ErrorMessage = "The last name should start with upper letter")]
        public string LastName { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
