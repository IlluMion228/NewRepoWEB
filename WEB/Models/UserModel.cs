using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(20, ErrorMessage = "First name cannot be longer than 20 characters.")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(20, ErrorMessage = "Last name cannot be longer than 20 characters.")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(80, ErrorMessage = "Email cannot be longer than 80 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(16, ErrorMessage = "Password cannot be longer than 16 characters.")]
        public string Password { get; set; }
    }
}
