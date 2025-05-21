
namespace Railway.Domain.Seats
{
    public interface ISeatRepository
    {
        public Task<List<SeatInfo>> GetSeatsByCarriageId(int trainId,
        int carriageId,
        int departureStationId,
        int arrivalStationId);
        
    }
}
