using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class HelpRequestModel
    {
        [Key]
        public int RequestId { get; set; }

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

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(10, ErrorMessage = "Phone number must be 10 digits.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "User message is required.")]
        [StringLength(400, ErrorMessage = "Message cannot be longer than 400 characters.")]
        public string UserMessage { get; set; }

        [Required]
        public bool WasPassenger { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
    }
}
