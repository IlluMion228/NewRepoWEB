using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class Extra
    {
        [Key]
        public int ExtraId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public virtual ICollection<BookingExtra> BookingExtras { get; set; }
    }
}
