using Railway.Domain.Routes;
using Railway.Domain.Stations;

namespace Railway.Domain.RouteStations;

public partial class RouteStation
{
    public int Id { get; set; }

    public int? RouteId { get; set; }

    public int? StationId { get; set; }

    public int? SequenceNumber { get; set; }

    public TimeSpan? ArrivalTime { get; set; }

    public TimeSpan? DepartureTime { get; set; }

    public int? DayNumber { get; set; }

    public virtual Route? Route { get; set; }

    public virtual Station? Station { get; set; }
}
