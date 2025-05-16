using System.ComponentModel.DataAnnotations;

namespace Luxor.Data.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required] 
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; }
            = new List<Booking>();
        public ICollection<Feedback> Feedbacks { get; set; }
            = new List<Feedback>();
    }
}
