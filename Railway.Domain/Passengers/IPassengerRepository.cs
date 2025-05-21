namespace Railway.Domain.Passengers
{
    public interface IPassengerRepository
    {
        Task<Passenger?> GetByNameAsync(string firstName, string lastName);
        Task<Passenger> AddAsync(string firstName, string lastName);
    }
}
