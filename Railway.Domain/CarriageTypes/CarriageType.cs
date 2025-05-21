using Railway.Domain.Carriages;

namespace Railway.Domain.CarriageTypes;

public partial class CarriageType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Carriage> Carriages { get; set; } = new List<Carriage>();
}
