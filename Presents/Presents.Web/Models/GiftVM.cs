using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Presents.Web.Models
{
    public class GiftVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "ImageUrl is required.")]
        [Url(ErrorMessage = "Please enter valid URL.")]
        public string ImageUrl { get; set; } = null!;
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public bool IsTaken { get; set; }

        public string CategoryName { get; set; }
    }
}
