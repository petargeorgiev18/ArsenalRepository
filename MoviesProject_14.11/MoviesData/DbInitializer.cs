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
                new Movie { Title = "Inception", Director = "Christopher Nolan", Year = 2010, Genre = "Sci-Fi" },
                new Movie { Title = "The Godfather", Director = "Francis Ford Coppola", Year = 1972, Genre = "Crime" },
                new Movie { Title = "Pulp Fiction", Director = "Quentin Tarantino", Year = 1994, Genre = "Crime" },
                new Movie { Title = "The Dark Knight", Director = "Christopher Nolan", Year = 2008, Genre = "Action" },
                new Movie { Title = "Interstellar", Director = "Christopher Nolan", Year = 2014, Genre = "Sci-Fi" }
            );

            context.Actors.AddRange(
                new Actor { Name = "Leonardo DiCaprio", BirthCountry = "USA", BirthYear = 1974 },
                new Actor { Name = "Marlon Brando", BirthCountry = "USA", BirthYear = 1924 },
                new Actor { Name = "Samuel L. Jackson", BirthCountry = "USA", BirthYear = 1948 },
                new Actor { Name = "Christian Bale", BirthCountry = "UK", BirthYear = 1974 },
                new Actor { Name = "Matthew McConaughey", BirthCountry = "USA", BirthYear = 1969 }
            );

            context.SaveChanges();
        }
    }
}
