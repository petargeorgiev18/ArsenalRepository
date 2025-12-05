using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyManagement.Data;
using PartyManagement.Data.Entities;
using PartyManagement.Web.Models;

namespace PartyManagement.Web.Controllers
{
    public class OrganizersController : Controller
    {
        private readonly PartyManagementDbContext _context;
        public OrganizersController(PartyManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<OrganizerViewModel> organisers = await _context.Organisers
                .Select(o=> new OrganizerViewModel
                {
                     Id = o.Id,
                     Name = o.Name,
                     PhoneNumber = o.PhoneNumber
                }).ToListAsync();

            return View(organisers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrganizerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Organiser organiser = new Organiser
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber
            };

            await _context.Organisers.AddAsync(organiser);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var organiser = await _context.Organisers.FindAsync(id);
            if (organiser == null)
                return NotFound();

            var model = new OrganizerViewModel
            {
                Id = organiser.Id,
                Name = organiser.Name,
                PhoneNumber = organiser.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrganizerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var organiser = await _context.Organisers.FindAsync(model.Id);
            if (organiser == null)
                return NotFound();

            organiser.Name = model.Name;
            organiser.PhoneNumber = model.PhoneNumber;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            Organiser? organiser = await _context.Organisers.FirstOrDefaultAsync(o => o.Id == id);
            if (organiser == null)
                return NotFound();

            _context.Organisers.Remove(organiser);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
