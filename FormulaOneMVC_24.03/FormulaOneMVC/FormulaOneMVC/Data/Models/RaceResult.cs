using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneMVC.Data.Models;

[Table("Race_Results")]
public partial class RaceResult
{
    [Key]
    [Column("result_id")]
    public int ResultId { get; set; }

    [Column("race_id")]
    public int? RaceId { get; set; }

    [Column("driver_id")]
    public int? DriverId { get; set; }

    [Column("position")]
    public int Position { get; set; }

    [Column("points", TypeName = "decimal(5, 2)")]
    public decimal Points { get; set; }

    [Column("laps")]
    public int Laps { get; set; }

    [Column("time")]
    public TimeOnly? Time { get; set; }

    [ForeignKey("DriverId")]
    [InverseProperty("RaceResults")]
    public virtual Driver? Driver { get; set; }

    [ForeignKey("RaceId")]
    [InverseProperty("RaceResults")]
    public virtual Race? Race { get; set; }
}
