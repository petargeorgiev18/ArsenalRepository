using System.ComponentModel.DataAnnotations;

namespace PartyManagement.Web.Models
{
    public class PartyViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = null!;

        public DateTime? Date { get; set; }
        [Required(ErrorMessage = "Image URL is required.")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Location is required.")]
        public Guid LocationId { get; set; }

        [Required(ErrorMessage = "Organizer is required.")]
        public Guid OrganizerId { get; set; }

        public string? LocationName { get; set; }
        public string? OrganizerName { get; set; }
    }
}
