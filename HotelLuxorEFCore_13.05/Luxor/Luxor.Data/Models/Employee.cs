using System.ComponentModel.DataAnnotations;

namespace Luxor.Data.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        public string Position { get; set; } = string.Empty;
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public ICollection<EmployeeService> EmployeeServices { get; set; }
            = new List<EmployeeService>();
    }
}
