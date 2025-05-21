using Railway.Domain.Tickets;

namespace Railway.Domain.Passengers;

public partial class Passenger
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
