using EmployeeDepartmentProject.Core.Interfaces;
using EmployeeDepartmentProject.Data.Entities;
using EmployeeDepartmentProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentProject.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: Departments
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllAsync();
            return View(departments);
        }

        // GET: Departments/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new DepartmentFormViewModel());
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentFormViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var department = new Department
                {
                    Name = vm.Name,
                    Code = vm.Code
                };

                await _departmentService.CreateAsync(department);
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: Departments/Edit/Id
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null)
                return NotFound();

            var vm = new DepartmentFormViewModel
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code
            };

            return View(vm);
        }

        // POST: Departments/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentFormViewModel vm)
        {
            if (id != vm.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var department = new Department
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Code = vm.Code
                };

                await _departmentService.UpdateAsync(department);
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // POST: Departments/Delete/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
