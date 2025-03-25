using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneMVC.Data.Models;

public partial class Team
{
    [Key]
    [Column("team_id")]
    public int TeamId { get; set; }

    [Column("team_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string TeamName { get; set; } = null!;

    [Column("country")]
    [StringLength(100)]
    [Unicode(false)]
    public string Country { get; set; } = null!;

    [Column("foundation_year")]
    public int FoundationYear { get; set; }

    [InverseProperty("Team")]
    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
