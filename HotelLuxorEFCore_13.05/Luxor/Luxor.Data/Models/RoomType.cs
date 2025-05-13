using Luxor.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Luxor.Data.Models
{
    public class RoomType
    {
        [Key]
        public int RoomTypeId { get; set; }
        [Required]
        public TypeRoom Type { get; set; }
        public ICollection<Room> Rooms { get; set; }
                    = new List<Room>();
    }
}
