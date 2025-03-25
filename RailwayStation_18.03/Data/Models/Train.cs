using System;
using System.Collections.Generic;

namespace RailwayStation.Data.Models;

public partial class Train
{
    public int Id { get; set; }

    public string TrainNumber { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
