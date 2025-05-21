using Railway.Shared.Core;
using Railway.Shared.DTOs;

namespace Railway.Application.Services.Trains
{
    public interface ITrainService
    {
        public Task<Result<List<TrainCarriagesDTO>>> GetTrainCarriagesInfo(int trainId, int depatureStationId, int arrivalStationId);
    }
}
