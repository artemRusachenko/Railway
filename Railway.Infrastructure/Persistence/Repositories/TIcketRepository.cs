using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Railway.Domain.Routes;
using Railway.Domain.Tickets;

namespace Railway.Infrastructure.Persistence.Repositories
{
    public class TIcketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;
        public TIcketRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<GetPassengerTicketsSPResult>> GetPessangerTickets(int passengerId)
        {
            var passengerParam = new SqlParameter("@PassengerId", passengerId);

            var result = await _context
                .Set<GetPassengerTicketsSPResult>()
                .FromSqlRaw("EXEC GetPassengerTickets @PassengerId", passengerParam)
                .ToListAsync();

            return result;
        }

        public async Task<bool> AddTicket(int passengerId, int seatId, int depatureStationId, int arrivalStationId)
        {
            try
            {
                decimal price = CalculatePrice(depatureStationId, arrivalStationId);

                var ticket = new Ticket
                {
                    PassengerId = passengerId,
                    SeatId = seatId,
                    DepartureStationId = depatureStationId,
                    ArrivalStationId = arrivalStationId,
                    Price = price
                };

                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private decimal CalculatePrice(int departureStationId, int arrivalStationId)
        {
            var departure = _context.RouteStations
                .FirstOrDefault(rs => rs.StationId == departureStationId);

            var arrival = _context.RouteStations
                .FirstOrDefault(rs => rs.StationId == arrivalStationId);

            if (departure == null || arrival == null)
                throw new Exception("Одна зі станцій не знайдена в маршрутах");

            if (departure.RouteId != arrival.RouteId)
                throw new Exception("Станції не належать одному маршруту");

            int distance = Math.Abs((departure.SequenceNumber ?? 0) - (arrival.SequenceNumber ?? 0));
            return distance * 100;
        }
    }
}
