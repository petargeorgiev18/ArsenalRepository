using Microsoft.AspNetCore.Mvc;
using Presents.Data;
using Presents.Data.Entities;
using Presents.Web.Models;

namespace Presents.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly PresentsDbContext context;
        public CategoriesController(PresentsDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
                return View();

            Category category = new Category
            {
                Name = categoryVM.Name
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
