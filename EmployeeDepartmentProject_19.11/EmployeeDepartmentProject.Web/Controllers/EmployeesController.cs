using EmployeeDepartmentProject.Data;
using EmployeeDepartmentProject.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentProject.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeDepartmentDbContext _context;
        public EmployeesController(EmployeeDepartmentDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _context.Employees.ToListAsync();
            return View(employees);
        }

        // GET: Employees/Details/Id
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/Id
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            Employee? employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();
            ViewData["Departments"] = _context.Departments.ToList();
            return View(employee);
        }

        // POST: Employees/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id) 
                return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Departments"] = _context.Departments.ToList();
            return View(employee);
        }

        // GET: Employees/Delete/Id
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) 
                return NotFound();
            Employee? employee = await _context.Employees
                .Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) 
                return NotFound();
            return View(employee);
        }

        // POST: Employees/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
