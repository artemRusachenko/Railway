namespace Railway.Domain.Routes
{
    public class RouteBetweenStationSPResult
    {
        public int TrainId { get; set; }
        public string TrainNumber { get; set; }
        public string RouteName { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string DepartureStationName { get; set; }
        public string ArrivalStationName { get; set; }
        public int DepatureStationId { get; set; }
        public int ArrivalStationId { get; set; }
    }
}
