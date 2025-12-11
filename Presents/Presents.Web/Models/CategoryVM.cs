using System.ComponentModel.DataAnnotations;

namespace Presents.Web.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        public string Name { get; set; } = null!;
    }
}
