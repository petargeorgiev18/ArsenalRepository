using System;
using System.Collections.Generic;

namespace RailwayStation.Data.Models;

public partial class Route
{
    public int Id { get; set; }

    public int? TrainId { get; set; }

    public string DepartureStation { get; set; } = null!;

    public string ArrivalStation { get; set; } = null!;

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Train? Train { get; set; }
}
