using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presents.Web.Models
{
    public class GiftIndexVM
    {
        public int? CategoryId { get; set; }
        public List<GiftVM> Gifts { get; set; } = new List<GiftVM>();
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}