namespace Railway.Shared.DTOs
{
    public class SeatInfoDTO
    {
        public int SeatId { get; set; }
        public int CarriageId { get; set; }
        public int SeatNumber { get; set; }
        public bool IsFree { get; set; }
    }
}
