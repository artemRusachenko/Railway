using Microsoft.EntityFrameworkCore;
using Railway.Domain.Passengers;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Persistence.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly AppDbContext _context;

        public PassengerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Passenger?> GetByNameAsync(string firstName, string lastName)
        {
            return await _context.Passengers
                .FirstOrDefaultAsync(p => p.FirstName == firstName && p.LastName == lastName);
        }

        public async Task<Passenger> AddAsync(string firstName, string lastName)
        {
            var passenger = new Passenger
            {
                FirstName = firstName,
                LastName = lastName
            };

            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();

            return passenger;
        }
    }
}
