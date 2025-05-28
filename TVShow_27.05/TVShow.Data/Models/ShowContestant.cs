using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVShow.Data.Models
{
    public class ShowContestant
    {
        [Required]
        [ForeignKey(nameof(Show))]
        public int ShowId { get; set; }
        public Show Show { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Contestant))]
        public int ContestantId { get; set; }
        public Contestant Contestant { get; set; } = null!;
    }
}