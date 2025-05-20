using System.ComponentModel.DataAnnotations;
using static Luxor.Common.EntityClassesValidation.Service;

namespace Luxor.Data.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        [MaxLength(ServiceNameMaxLength)]
        public string ServiceName { get; set; } = string.Empty;
        [Required]
        [MaxLength(ServiceDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        public ICollection<EmployeeService> EmployeeServices { get; set; }
            = new List<EmployeeService>();
        public ICollection<BookingService> BookingServices { get; set; }
            = new List<BookingService>();
    }
}