using System;
using System.Collections.Generic;

namespace RailwayStation.Data.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string PassengerName { get; set; } = null!;

    public int TrainId { get; set; }

    public int RouteId { get; set; }

    public string SeatNumber { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Route Route { get; set; } = null!;

    public virtual Train Train { get; set; } = null!;
}
