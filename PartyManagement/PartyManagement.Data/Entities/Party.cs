using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PartyManagement.Data.Entities
{
    public class Party
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Location))]
        public Guid LocationId { get; set; }
        public Location Location { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Organiser))]
        public Guid OrganiserId { get; set; }
        public Organiser Organiser { get; set; } = null!;
    }
}
