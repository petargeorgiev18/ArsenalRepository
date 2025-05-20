using System.ComponentModel.DataAnnotations;
using static Luxor.Common.EntityClassesValidation.Employee;

namespace Luxor.Data.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(EmployeeFirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(EmployeeLastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(EmployeePositionMaxLength)]
        public string Position { get; set; } = string.Empty;
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public ICollection<EmployeeService> EmployeeServices { get; set; }
            = new List<EmployeeService>();
    }
}
