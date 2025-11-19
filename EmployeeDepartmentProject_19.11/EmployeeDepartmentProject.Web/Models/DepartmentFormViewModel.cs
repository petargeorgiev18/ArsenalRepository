using EmployeeDepartmentProject.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDepartmentProject.Web.Models
{
    public class DepartmentFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(2)]
        public string Code { get; set; } = null!;
    }
}
