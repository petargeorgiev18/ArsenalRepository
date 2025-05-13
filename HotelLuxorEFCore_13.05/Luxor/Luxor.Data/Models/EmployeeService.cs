using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Luxor.Data.Models
{
    [PrimaryKey(nameof(EmployeeId), nameof(ServiceId))]
    public class EmployeeService
    {
        [Required]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
