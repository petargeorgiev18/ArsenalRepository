using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShow.Data.Models
{
    public class Contestant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = null!;
        public int? Age { get; set; }
        [EmailAddress]
        public string? ContactEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<ShowContestant> ShowContestants { get; set; } 
            = new List<ShowContestant>();
    }
}
