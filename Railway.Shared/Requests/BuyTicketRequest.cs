namespace Railway.Shared.Requests
{
    public class BuyTicketRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SeatId { get; set; }
        public DateTime DepartureDate { get; set; }
        public int DepartureStationId { get; set; }
        public int ArrivalStationId { get; set; }
    }
}
