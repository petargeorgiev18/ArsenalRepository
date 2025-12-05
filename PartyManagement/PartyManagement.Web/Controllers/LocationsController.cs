using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyManagement.Data;
using PartyManagement.Data.Entities;
using PartyManagement.Web.Models;

namespace PartyManagement.Web.Controllers
{
    public class LocationsController : Controller
    {
        private readonly PartyManagementDbContext _context;
        public LocationsController(PartyManagementDbContext context) 
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<LocationViewModel> locations = await _context.Locations
                .Select(l => new LocationViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Address = l.Address,
                }).ToListAsync();

            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LocationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Location location = new Location
            {
                Name = model.Name,
                Address = model.Address
            };

            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            Location? location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);
            if (location == null)
                return NotFound();

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
