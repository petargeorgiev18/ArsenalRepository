using System.ComponentModel.DataAnnotations;
using static Luxor.Common.EntityClassesValidations.Employee;

namespace Luxor.Data.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(EmployeeNameMaxLength)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(EmployeePositionMaxLength)]
        public string Position { get; set; } = string.Empty;
        [Required]
        [MaxLength(EmployeeSalaryMaxLength)]
        public decimal Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public ICollection<EmployeeService> EmployeeServices { get; set; }
            = new List<EmployeeService>();
    }
}
