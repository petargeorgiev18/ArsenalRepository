using Microsoft.AspNetCore.Mvc;
using MoviesData;
using MoviesData.Entities;

namespace MoviesWebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext context;
        public MoviesController(MovieContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            List<Movie> movies = context.Movies.ToList();
            return View(movies);
        }

        // GET: Movie/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
            return RedirectToAction("Create");
        }

        //GET: Movie/Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            Movie? movie = context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        //POST: Movie/Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Movie? movie = context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Movie/Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie? movie = context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        //POST: Movie/Edit
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            context.Movies.Update(movie);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
