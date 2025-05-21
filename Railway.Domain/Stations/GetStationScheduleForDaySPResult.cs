namespace Railway.Domain.Stations
{
    public class GetStationScheduleForDaySPResult
    {
        public int TrainId { get; set; }
        public string TrainNumber { get; set; }
        public string RouteName { get; set; }
        public string StationName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime FinalArrivalTime { get; set; }
        public string FinalStationName { get; set; }
    }
}
