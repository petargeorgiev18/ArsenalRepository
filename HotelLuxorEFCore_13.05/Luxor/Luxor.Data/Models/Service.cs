using System.ComponentModel.DataAnnotations;

namespace Luxor.Data.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        public string ServiceName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        public ICollection<EmployeeService> EmployeeServices { get; set; }
            = new List<EmployeeService>();
        public ICollection<BookingService> BookingServices { get; set; }
            = new List<BookingService>();
    }
}