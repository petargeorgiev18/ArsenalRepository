using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class ImportCarDto
    {
        [Required]
        [JsonProperty("make")]
        public string Make { get; set; } = null!;
        [Required]
        [JsonProperty("model")]
        public string Model { get; set; } = null!;
        [Required]
        [JsonProperty("traveledDistance")]
        public long TraveledDistance { get; set; }
        [Required]
        [JsonProperty("partsId")]
        public ICollection<int> PartsId { get; set; } = new HashSet<int>();
    }
}
