using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Railway.Domain.Stations;
using System.Data;

namespace Railway.Infrastructure.Persistence.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly AppDbContext _context;
        public StationRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<List<GetStationScheduleForDaySPResult>> GetStationScheduleForDaySPResult(int stationId, DateTime ScheduleDate)
        {
            var statParam = new SqlParameter("@StationId", stationId);
            var dateParam = new SqlParameter("@ScheduleDate", ScheduleDate.Date);

            var result = await _context
                .Set<GetStationScheduleForDaySPResult>()
                .FromSqlRaw("EXEC GetStationScheduleForDay @StationId, @ScheduleDate", statParam, dateParam)
                .ToListAsync();

            return result;
        }

        public async Task<List<GetStationsForRouteSPResult>> GetStationScheduleForRoute(int? stationId, bool isArrival)
        {
            var stationParam = new SqlParameter("@SelectedStationId", SqlDbType.Int);
            stationParam.Value = stationId.HasValue ? stationId.Value : (object)DBNull.Value;

            var isArrivalParam = new SqlParameter("@IsArrival", SqlDbType.Bit)
            {
                Value = isArrival
            };

            var result = await _context.Set<GetStationsForRouteSPResult>()
                .FromSqlRaw("EXEC GetStationsForRoute @SelectedStationId, @IsArrival", stationParam, isArrivalParam)
                .ToListAsync();

            return result;
        }

    }
}
