using System;
using System.Collections.Generic;

namespace RailwayStation.Data.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int? TrainId { get; set; }

    public virtual Train? Train { get; set; }
}
