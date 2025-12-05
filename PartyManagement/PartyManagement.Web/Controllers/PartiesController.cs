using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartyManagement.Data;
using PartyManagement.Data.Entities;
using PartyManagement.Web.Models;

namespace PartyManagement.Web.Controllers
{
    public class PartiesController : Controller
    {
        private readonly PartyManagementDbContext _context;
        public PartiesController(PartyManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var parties = await _context.Parties
                .Include(p => p.Location)
                .Include(p => p.Organiser)
                .Select(p => new PartyViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Date = p.Date,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    LocationId = p.LocationId,
                    OrganizerId = p.OrganiserId,
                    LocationName = p.Location.Name,
                    OrganizerName = p.Organiser.Name
                })
                .ToListAsync();

            return View(parties);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name");
            ViewBag.Organizers = new SelectList(await _context.Organisers.ToListAsync(), "Id", "Name");
            return View(new PartyViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PartyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name", model.LocationId);
                ViewBag.Organizers = new SelectList(await _context.Organisers.ToListAsync(), "Id", "Name", model.OrganizerId);
                return View(model);
            }

            var party = new Party
            {
                Title = model.Title,
                Date = model.Date ?? DateTime.Now,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                LocationId = model.LocationId,
                OrganiserId = model.OrganizerId
            };

            await _context.Parties.AddAsync(party);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var party = await _context.Parties.FindAsync(id);
            if (party == null) return NotFound();

            var model = new PartyViewModel
            {
                Id = party.Id,
                Title = party.Title,
                Date = party.Date,
                ImageUrl = party.ImageUrl,
                Description = party.Description,
                LocationId = party.LocationId,
                OrganizerId = party.OrganiserId
            };

            ViewBag.Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name", model.LocationId);
            ViewBag.Organizers = new SelectList(await _context.Organisers.ToListAsync(), "Id", "Name", model.OrganizerId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PartyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Locations = new SelectList(await _context.Locations.ToListAsync(), "Id", "Name", model.LocationId);
                ViewBag.Organizers = new SelectList(await _context.Organisers.ToListAsync(), "Id", "Name", model.OrganizerId);
                return View(model);
            }

            var party = await _context.Parties.FindAsync(model.Id);
            if (party == null) return NotFound();

            party.Title = model.Title;
            party.Date = model.Date ?? DateTime.Now;
            party.ImageUrl = model.ImageUrl;
            party.Description = model.Description;
            party.LocationId = model.LocationId;
            party.OrganiserId = model.OrganizerId;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var party = await _context.Parties.FindAsync(id);
            if (party == null) return NotFound();

            _context.Parties.Remove(party);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}