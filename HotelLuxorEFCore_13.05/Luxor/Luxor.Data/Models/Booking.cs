using Luxor.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Luxor.Common.EntityClassesValidations.Booking;

namespace Luxor.Data.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public DateTime AccommodationDate { get; set; }
        [Required]
        public DateTime LeavingDate { get; set; }
        [Required]
        [MaxLength(BookingAmountMaxLength)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; } = string.Empty;
        [Required]
        public Status Status { get; set; }
        [Required]
        [ForeignKey(nameof(Guest))]
        public int GuestId { get; set; }
        public Guest Guest { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public ICollection<BookingService> BookingServices { get; set; }
            = new List<BookingService>();
        public ICollection<Feedback> Feedbacks { get; set; }
            = new List<Feedback>();
    }
}
