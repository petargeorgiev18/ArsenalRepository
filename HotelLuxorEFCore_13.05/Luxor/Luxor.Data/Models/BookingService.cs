using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Luxor.Data.Models
{
    [PrimaryKey(nameof(BookingId), nameof(ServiceId))]
    public class BookingService
    {
        [Required]
        [ForeignKey(nameof(Booking))]
        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
