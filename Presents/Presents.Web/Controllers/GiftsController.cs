using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presents.Data;
using Presents.Data.Entities;
using Presents.Web.Models;

namespace Presents.Web.Controllers
{
    public class GiftsController : Controller
    {
        private readonly PresentsDbContext context;
        public GiftsController(PresentsDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            var categories = await context.Categories.ToListAsync();
            var giftsQuery = context.Gifts.Include(g => g.Category).AsQueryable();

            if (categoryId != null)
                giftsQuery = giftsQuery.Where(g => g.CategoryId == categoryId);

            var gifts = await giftsQuery.ToListAsync();

            var model = new GiftIndexVM
            {
                CategoryId = categoryId,
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList(),
                Gifts = gifts.Select(g => new GiftVM
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    CategoryId = g.CategoryId,
                    IsTaken = g.IsTaken,
                    CategoryName = g.Category.Name
                }).ToList()
            };

            var categ = await context.Categories.FirstOrDefaultAsync(x => x.Id == model.CategoryId);

            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            GiftVM model = new GiftVM
            {
                Categories = context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GiftVM giftVM)
        {
            if (!ModelState.IsValid)
            {
                giftVM.Categories = context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToList();

                return View(giftVM);
            }

            Gift gift = new Gift()
            {
                Name = giftVM.Name,
                Description = giftVM.Description,
                ImageUrl = giftVM.ImageUrl,
                CategoryId = giftVM.CategoryId,
                IsTaken = false
            };

            await context.Gifts.AddAsync(gift);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Gift gift = await context.Gifts.FirstOrDefaultAsync(g => g.Id == id);
            if (gift == null)
                return NotFound();

            context.Gifts.Remove(gift);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Draw()
        {
            List<Gift> gifts = await context.Gifts.Where(g => !g.IsTaken).ToListAsync();

            if (!gifts.Any())
                return Content("Няма налични подаръци!");

            Random r = new Random();
            Gift selected = gifts[r.Next(gifts.Count)];

            var categ = await context.Categories.FirstOrDefaultAsync(x => x.Id == selected.CategoryId);

            ViewBag.CategoryName = categ.Name;

            selected.IsTaken = true;
            await context.SaveChangesAsync();

            return View("Draw", selected);
        }
    }
}
