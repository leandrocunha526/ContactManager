using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MinLength(6, ErrorMessage = "The Name field must have at least 6 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Phone field is required.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "The Phone field must have a maximum of 9 digits.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedAt { get; set; }
    }
}
