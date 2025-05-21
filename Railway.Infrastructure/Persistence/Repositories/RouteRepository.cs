using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Railway.Domain.Routes;

namespace Railway.Infrastructure.Persistence.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly AppDbContext _context;
        public RouteRepository(AppDbContext appDbContext) 
        {
            _context = appDbContext;
        }

        public async Task<ICollection<RouteBetweenStationSPResult>> GetRoutesBetweenStations(int depStation, int arrStation, DateTime depaturedate)
        {
            var depParam = new SqlParameter("@DepStation", depStation);
            var arrParam = new SqlParameter("@ArrStation", arrStation);
            var dateParam = new SqlParameter("@DepartureDate", depaturedate);

            var result = await _context
                .Set<RouteBetweenStationSPResult>()
                .FromSqlRaw("EXEC FindRoutesBetweenStations @DepStation, @ArrStation, @DepartureDate", depParam, arrParam, dateParam)
                .ToListAsync();

            return result;
        }
    }
}
