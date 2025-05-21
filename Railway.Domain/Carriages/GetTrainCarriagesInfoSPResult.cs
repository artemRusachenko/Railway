namespace Railway.Domain.Carriages
{
    public class GetTrainCarriagesInfoSPResult
    {
        public int CarriageId { get; set; }
        public int CarriageNumber { get; set; }
        public string CarriageType { get; set; }
        public int TotalSeats { get; set; }
        public int FreeSeats { get; set; }
    }
}
