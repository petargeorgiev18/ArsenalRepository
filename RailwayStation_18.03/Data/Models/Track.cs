using System;
using System.Collections.Generic;

namespace RailwayStation.Data.Models;

public partial class Track
{
    public int Id { get; set; }

    public string StationName { get; set; } = null!;

    public int TrackNumber { get; set; }

    public int? TrainId { get; set; }

    public virtual Train? Train { get; set; }
}
