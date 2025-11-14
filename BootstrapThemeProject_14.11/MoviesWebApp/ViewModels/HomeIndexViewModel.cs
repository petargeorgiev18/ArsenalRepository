using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesData.Entities;

namespace MoviesWebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Actor> Actors { get; set; } = new List<Actor>();
    }
}
