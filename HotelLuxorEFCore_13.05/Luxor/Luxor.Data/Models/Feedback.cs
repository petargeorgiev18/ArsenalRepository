using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Luxor.Common.EntityClassesValidations.Feedback;

namespace Luxor.Data.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        [Required]
        [MaxLength(FeedbackCommentMaxLength)]
        public string Comment { get; set; } = null!;
        [Required]
        public int Rating { get; set; }
        [Required]
        public DateTime PublishedOn { get; set; }
        [Required]
        [ForeignKey(nameof(Booking))]
        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Guest))]
        public int GuestId { get; set; }
        public Guest Guest { get; set; } = null!;
    }
}
