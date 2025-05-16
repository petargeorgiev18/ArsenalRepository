using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Luxor.Common.EntityClassesValidation.Room;

namespace Luxor.Data.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        [MaxLength(RoomNumberMaxLength)]
        public string RoomNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(RoomDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        [ForeignKey(nameof(RoomType))]
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } 
            = new List<Booking>();
    }
}
