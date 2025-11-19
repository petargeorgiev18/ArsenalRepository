using EmployeeDepartmentProject.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDepartmentProject.Web.Models
{
    public class EmployeeFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; } = new();
    }
}