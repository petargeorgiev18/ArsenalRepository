using System.ComponentModel.DataAnnotations;

namespace Presents.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
