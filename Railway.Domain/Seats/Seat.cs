using System;
using System.Collections.Generic;

namespace Railway.Infrastructure.Persistence.Models;

public partial class Seat
{
    public int Id { get; set; }

    public int? CarriageId { get; set; }

    public int? SeatNumber { get; set; }

    public virtual Carriage? Carriage { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
