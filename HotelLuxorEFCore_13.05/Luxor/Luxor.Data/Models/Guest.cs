using System.ComponentModel.DataAnnotations;

namespace Luxor.Data.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required] 
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        public ICollection<Booking> Bookings { get; set; }
            = new List<Booking>();
        public ICollection<Feedback> Feedbacks { get; set; }
            = new List<Feedback>();
    }
}
