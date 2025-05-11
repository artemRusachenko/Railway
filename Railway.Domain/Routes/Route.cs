using System;
using System.Collections.Generic;

namespace Railway.Infrastructure.Persistence.Models;

public partial class Route
{
    public int Id { get; set; }

    public string? RouteName { get; set; }

    public string? RouteNumber { get; set; }

    public virtual ICollection<RouteStation> RouteStations { get; set; } = new List<RouteStation>();

    public virtual ICollection<Train> Trains { get; set; } = new List<Train>();
}
