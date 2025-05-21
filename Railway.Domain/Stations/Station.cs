using Railway.Domain.RouteStations;
using Railway.Domain.Tickets;

namespace Railway.Domain.Stations;

public partial class Station
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<RouteStation> RouteStations { get; set; } = new List<RouteStation>();

    public virtual ICollection<Ticket> TicketArrivalStations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketDepartureStations { get; set; } = new List<Ticket>();
}
