using Microsoft.EntityFrameworkCore;
using MoviesData.Entities;

namespace MoviesData
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Actor> Actors { get; set; } = null!;
    }
}
