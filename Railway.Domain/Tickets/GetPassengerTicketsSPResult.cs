namespace Railway.Domain.Tickets
{
    public class GetPassengerTicketsSPResult
    {
        public int TicketId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TrainNumber { get; set; }
        public int SeatNumber { get; set; }
        public int CarriageNumber { get; set; }
        public string CarriageType { get; set; }
        public DateTime FromDateTime { get; set; }
        public string DepartureStation { get; set; }
        public DateTime ToDateTime { get; set; }
        public string ArrivalStation { get; set; }
    }
}
