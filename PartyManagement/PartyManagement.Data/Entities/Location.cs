using System.ComponentModel.DataAnnotations;

namespace PartyManagement.Data.Entities
{
    public class Location
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = null!;
    }
}
