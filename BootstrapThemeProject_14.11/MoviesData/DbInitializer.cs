using System;
using System.Linq;
using MoviesData.Entities;

namespace MoviesData
{
    public static class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {
            context.Database.EnsureCreated();
            if (context.Movies.Any() || context.Actors.Any())
            {
                context.Movies.RemoveRange(context.Movies);
                context.Actors.RemoveRange(context.Actors);
                context.SaveChanges();
            }

            context.Movies.AddRange(
                new Movie { Title = "Inception", Director = "Christopher Nolan", Year = 2010, Genre = "Sci-Fi", ImageUrl="/images/movies/inception.jpg" },
                new Movie { Title = "The Godfather", Director = "Francis Ford Coppola", Year = 1972, Genre = "Crime", ImageUrl = "/images/movies/godfather.jpg" },
                new Movie { Title = "Pulp Fiction", Director = "Quentin Tarantino", Year = 1994, Genre = "Crime", ImageUrl = "/images/movies/pulp_fiction.jpg" },
                new Movie { Title = "The Dark Knight", Director = "Christopher Nolan", Year = 2008, Genre = "Action", ImageUrl = "/images/movies/the_dark_knight.jpg" },
                new Movie { Title = "Interstellar", Director = "Christopher Nolan", Year = 2014, Genre = "Sci-Fi", ImageUrl = "/images/movies/interstellar.jpg" }
            );

            context.Actors.AddRange(
                new Actor { Name = "Leonardo DiCaprio", BirthCountry = "USA", BirthYear = 1974, ImageUrl= "/images/actors/leonardodicaprio.jpg" },
                new Actor { Name = "Marlon Brando", BirthCountry = "USA", BirthYear = 1924, ImageUrl = "/images/actors/marlonbrando.jpg" },
                new Actor { Name = "Samuel L. Jackson", BirthCountry = "USA", BirthYear = 1948, ImageUrl = "/images/actors/samueljackson.jpg" },
                new Actor { Name = "Christian Bale", BirthCountry = "UK", BirthYear = 1974, ImageUrl = "/images/actors/christianbale.jpg" },
                new Actor { Name = "Matthew McConaughey", BirthCountry = "USA", BirthYear = 1969, ImageUrl = "/images/actors/matthewmcconaughey.jpg" }
            );

            context.SaveChanges();
        }
    }
}
