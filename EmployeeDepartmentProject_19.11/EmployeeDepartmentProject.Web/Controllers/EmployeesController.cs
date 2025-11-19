using EmployeeDepartmentProject.Core.Interfaces;
using EmployeeDepartmentProject.Data.Entities;
using EmployeeDepartmentProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentProject.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeesController(
            IEmployeeService employeeService,
            IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        // GET: Employees
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _employeeService.GetAllAsync();
            return View(employees);
        }

        // GET: Employees/Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EmployeeFormViewModel vm = new EmployeeFormViewModel
            {
                DateOfBirth = DateTime.Today,
                Departments = await _departmentService.GetAllAsync()
            };

            return View(vm);
        }

        // POST: Employees/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(EmployeeFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Departments = await _departmentService.GetAllAsync();
                return View(vm);
            }

            Employee employee = new Employee
            {
                Name = vm.Name,
                Email = vm.Email,
                DateOfBirth = vm.DateOfBirth,
                Salary = vm.Salary,
                DepartmentId = vm.DepartmentId
            };

            await _employeeService.AddAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/Edit/Id
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            EmployeeFormViewModel vm = new EmployeeFormViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId,
                Departments = await _departmentService.GetAllAsync()
            };

            return View(vm);
        }

        // POST: Employees/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeFormViewModel vm)
        {
            if (id != vm.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                vm.Departments = await _departmentService.GetAllAsync();
                return View(vm);
            }

            Employee employee = new Employee
            {
                Id = vm.Id,
                Name = vm.Name,
                Email = vm.Email,
                DateOfBirth = vm.DateOfBirth,
                Salary = vm.Salary,
                DepartmentId = vm.DepartmentId
            };

            await _employeeService.UpdateAsync(employee);

            return RedirectToAction(nameof(Index));
        }

        // POST: Employees/Delete/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}