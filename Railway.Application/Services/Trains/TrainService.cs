using Railway.Shared.DTOs;
using Railway.Domain.Trains;
using Railway.Shared.Core;

namespace Railway.Application.Services.Trains
{
    public class TrainService : ITrainService
    {
        private readonly ITrainRepository _trainRepository;

        public TrainService(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<Result<List<TrainCarriagesDTO>>> GetTrainCarriagesInfo(int trainId, int depatureStationId, int arrivalStationId)
        {
            try
            {
                var spResults = await _trainRepository.GetTrainCarriagesInfo(trainId, depatureStationId, arrivalStationId);

                if (spResults == null || spResults.Count == 0)
                {
                    return ResultBuilder.Failure<List<TrainCarriagesDTO>>(new Exception("Інформацію про вагони не знайдено."));
                }

                var result = spResults.Select(r => new TrainCarriagesDTO
                {
                    CarriageId = r.CarriageId,
                    CarriageNumber = r.CarriageNumber,
                    CarriageType = r.CarriageType,
                    TotalSeats = r.TotalSeats,
                    FreeSeats = r.FreeSeats
                }).ToList();

                return ResultBuilder.Success(result);
            }
            catch (Exception ex)
            {
                return ResultBuilder.Failure<List<TrainCarriagesDTO>>(ex);
            }
        }
    }
}
