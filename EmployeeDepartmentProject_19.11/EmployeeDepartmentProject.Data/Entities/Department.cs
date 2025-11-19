using System.ComponentModel.DataAnnotations;

namespace EmployeeDepartmentProject.Data.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Code { get; set; } = null!;
        public ICollection<Employee> Employees { get; set; } 
            = new HashSet<Employee>();
    }
}
