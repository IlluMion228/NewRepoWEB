using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class Help
    {
        [Key]
        public int RequestId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(20, ErrorMessage = "First Name cannot be longer than 20 characters.")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(20, ErrorMessage = "Last Name cannot be longer than 20 characters.")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(80, ErrorMessage = "Email cannot be longer than 80 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(10, ErrorMessage = "Phone number cannot be longer than 10 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(400, ErrorMessage = "Message cannot be longer than 400 characters.")]
        public string UserMessage { get; set; }

        [Required(ErrorMessage = "Please specify whether you were a passenger.")]
        public bool WasPassenger { get; set; }

        [Required(ErrorMessage = "Request date is required.")]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }
    }
}
