﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public decimal Discount { get; set; }
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public virtual Car Car { get; set; } = null!;
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!; 
    }
}
