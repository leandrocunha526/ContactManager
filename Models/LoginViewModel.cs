using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email, please enter with a correct email.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Password field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
