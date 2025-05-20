using System.ComponentModel.DataAnnotations;
using static Luxor.Common.EntityClassesValidation.Guest;

namespace Luxor.Data.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        [Required]
        [MaxLength(GuestFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(GuestLastNameMaxLength)]
        public string LastName { get; set; } = null!;
        [Required]
        [MaxLength(GuestEmailMaxLength)]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(GuestPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [MaxLength(GuestPasswordMaxLength)]
        public string Password { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; }
            = new List<Booking>();
        public ICollection<Feedback> Feedbacks { get; set; }
            = new List<Feedback>();
    }
}
