using Railway.Domain.Stations;
using Railway.Shared.Core;
using Railway.Shared.DTOs;

namespace Railway.Application.Services.Stations
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<Result<List<StationScheduleForDayDTO>>> GetStationScheduleForDay(int stationId, DateTime scheduleDate)
        {
            try
            {
                var results = await _stationRepository.GetStationScheduleForDaySPResult(stationId, scheduleDate);

                var mapped = results.Select(r => new StationScheduleForDayDTO
                {
                    TrainId = r.TrainId,
                    TrainNumber = r.TrainNumber,
                    RouteName = r.RouteName,
                    StationName = r.StationName,
                    ArrivalTime = r.ArrivalTime,
                    DepartureTime = r.DepartureTime,
                    FinalArrivalTime = r.FinalArrivalTime,
                    FinalStationName = r.FinalStationName
                }).ToList();

                return ResultBuilder.Success(mapped);
            }
            catch (Exception ex)
            {
                return ResultBuilder.Failure<List<StationScheduleForDayDTO>>(ex);
            }
        }

        public async Task<Result<List<StationForRouteDTO>>> GetStationScheduleForRoute(int? stationid, bool isArrival)
        {
            try
            {
                var results = await _stationRepository.GetStationScheduleForRoute(stationid, isArrival);
                var mapped = results.Select(r => new StationForRouteDTO
                {
                    Id = r.Id,
                    Name = r.Name
                }).ToList();

                return ResultBuilder.Success(mapped);
            }
            catch(Exception ex)
            {
                return ResultBuilder.Failure<List<StationForRouteDTO>>(ex);
            }
        }
    }
}
