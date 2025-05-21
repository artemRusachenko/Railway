using Railway.Shared.Core;
using Railway.Shared.DTOs;

namespace Railway.Application.Services.Stations
{
    public interface IStationService
    {
        public Task<Result<List<StationScheduleForDayDTO>>> GetStationScheduleForDay(int stationId, DateTime ScheduleDate);
        public Task<Result<List<StationForRouteDTO>>> GetStationScheduleForRoute(int? stationid, bool isArrival);
    }
}
