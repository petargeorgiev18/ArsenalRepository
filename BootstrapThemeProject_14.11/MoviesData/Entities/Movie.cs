using System.ComponentModel.DataAnnotations;

namespace MoviesData.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Director { get; set; } = null!;
        public int Year { get; set; }
        [Required]
        public string Genre { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
    }
}
