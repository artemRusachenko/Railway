namespace Railway.Shared.DTOs
{
    public class RouteBetweenStationsDTO
    {
        public int TrainId { get; set; }
        public string TrainNumber { get; set; }
        public string RouteName { get; set; }
        public DateTime DepatureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string DepatureStationName { get; set; }
        public string ArrivalStationName { get; set; }
        public int DepatureStationId { get; set; }
        public int ArrivalStationId { get; set; }
    }
}
