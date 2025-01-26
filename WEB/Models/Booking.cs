using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class Booking
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Display(Name = "Street Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Postal / Zip Code")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Will you return with us?")]
        public bool ReturnWithUs { get; set; }

        [Required]
        [Display(Name = "Taxi Fare Prices")]
        public string FarePrice { get; set; }

        public string? PromoCode { get; set; }
        public decimal Total { get; set; }
        
    }
}
