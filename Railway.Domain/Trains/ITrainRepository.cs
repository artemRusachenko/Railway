using Railway.Domain.Carriages;

namespace Railway.Domain.Trains
{
    public interface ITrainRepository
    {
        public Task<List<GetTrainCarriagesInfoSPResult>> GetTrainCarriagesInfo(int trainId, int depatureStationId, int arrivalStationId);
    }
}
