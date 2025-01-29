using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class BookingExtra
    {
        public int BookingId { get; set; }
        public int ExtraId { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Extra Extra { get; set; }
    }
}
