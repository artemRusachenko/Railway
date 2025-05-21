using Railway.Domain.CarriageTypes;
using Railway.Domain.Seats;
using Railway.Domain.Trains;

namespace Railway.Domain.Carriages;

public partial class Carriage
{
    public int Id { get; set; }

    public int? TrainId { get; set; }

    public int? CarriageTypeId { get; set; }

    public int? CarriageNumber { get; set; }

    public virtual CarriageType? CarriageType { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual Train? Train { get; set; }
}
