using System;
using System.Collections.Generic;

namespace Railway.Infrastructure.Persistence.Models;

public partial class Train
{
    public int Id { get; set; }

    public int? RouteId { get; set; }

    public DateTime? ArrivalDate { get; set; }

    public DateTime? DepatureDate { get; set; }

    public virtual ICollection<Carriage> Carriages { get; set; } = new List<Carriage>();

    public virtual Route? Route { get; set; }
}
