using Railway.Domain.Passengers;
using Railway.Domain.Seats;
using Railway.Domain.Stations;

namespace Railway.Domain.Tickets;

public partial class Ticket
{
    public int Id { get; set; }

    public int? SeatId { get; set; }

    public int? PassengerId { get; set; }

    public int? DepartureStationId { get; set; }

    public int? ArrivalStationId { get; set; }

    public decimal? Price { get; set; }

    public virtual Station? ArrivalStation { get; set; }

    public virtual Station? DepartureStation { get; set; }

    public virtual Passenger? Passenger { get; set; }

    public virtual Seat? Seat { get; set; }
}
