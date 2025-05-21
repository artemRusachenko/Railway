using Railway.Domain.Seats;
using Railway.Shared.Core;
using Railway.Shared.DTOs;

namespace Railway.Application.Services.Seats
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<Result<List<SeatInfoDTO>>> GetSeatsByCarriageId(int trainId, int carriageId, int departureStationId, int arrivalStationId)
        {
            try
            {
                var seats = await _seatRepository.GetSeatsByCarriageId(trainId, carriageId, departureStationId, arrivalStationId);

                if (seats == null || seats.Count == 0)
                    return ResultBuilder.Failure<List<SeatInfoDTO>>(new Exception("Seats not found"));

                var seatDtos = seats.Select(s => new SeatInfoDTO
                {
                    SeatId = s.SeatId,
                    CarriageId = carriageId,
                    SeatNumber = s.SeatNumber,
                    IsFree = s.IsFree
                }).ToList();

                return ResultBuilder.Success(seatDtos);
            }
            catch (Exception ex)
            {
                return ResultBuilder.Failure<List<SeatInfoDTO>>(ex);
            }
        }
    }
}
