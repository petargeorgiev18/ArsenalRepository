﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class ImportPartDto
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [Required]
        [JsonProperty("price")]
        public string Price { get; set; } = null!;
        [Required]
        [JsonProperty("quantity")]
        public string Quantity { get; set; } = null!;
        [Required]
        [JsonProperty("supplierId")]
        public string SupplierId { get; set; } = null!;
    }
}
