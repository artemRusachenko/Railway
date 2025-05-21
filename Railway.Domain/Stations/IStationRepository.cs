namespace Railway.Domain.Stations
{
    public interface IStationRepository
    {
        public Task<List<GetStationScheduleForDaySPResult>> GetStationScheduleForDaySPResult(int stationId, DateTime ScheduleDate);
        public Task<List<GetStationsForRouteSPResult>> GetStationScheduleForRoute(int? stationId, bool isArrival);
    }
}
