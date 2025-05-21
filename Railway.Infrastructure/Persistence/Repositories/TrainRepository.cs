using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Railway.Domain.Carriages;
using Railway.Domain.Passengers;
using Railway.Domain.Tickets;
using Railway.Domain.Trains;

namespace Railway.Infrastructure.Persistence.Repositories
{
    public class TrainRepository : ITrainRepository
    {
        private readonly AppDbContext _context;
        public TrainRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<GetTrainCarriagesInfoSPResult>> GetTrainCarriagesInfo(int trainId, int depatureStationId, int arrivalStationId)
        {
            var trainIdParam = new SqlParameter("@TrainId", trainId);
            var departureStationIdParam = new SqlParameter("@DepartureStationId", depatureStationId);
            var arrivalStationIdParam = new SqlParameter("@ArrivalStationId", arrivalStationId);

            var result = await _context
                .Set<GetTrainCarriagesInfoSPResult>()
                .FromSqlRaw("EXEC GetTrainCarriagesInfo @TrainId, @DepartureStationId, @ArrivalStationId", trainIdParam, departureStationIdParam, arrivalStationIdParam)
                .ToListAsync();

            return result;
        }
    }
}
