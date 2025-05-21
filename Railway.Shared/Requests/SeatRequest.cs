namespace Railway.Shared.Requests
{
    public class SeatRequest
    {
        public int TrainId { get; set; }
        public int CarriageId { get; set; }
        public int DepartureStationId { get; set; }
        public int ArrivalStationId { get; set; }
    }
}
