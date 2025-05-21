using Railway.Domain.Seats;
using Railway.Shared.Core;
using Railway.Shared.DTOs;

namespace Railway.Application.Services.Seats
{
    public interface ISeatService
    {
        public Task<Result<List<SeatInfoDTO>>> GetSeatsByCarriageId(int trainId, int carriageId, int departureStationId, int arrivalStationId);
    }
}
