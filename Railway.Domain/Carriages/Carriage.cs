namespace Railway.Infrastructure.Persistence.Models;

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
