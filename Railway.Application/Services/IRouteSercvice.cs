using Railway.Shared.Core;
using Railway.Shared.DTOs;

namespace Railway.Application.Services
{
    public interface IRouteSercvice
    {
        public Task<Result<List<RouteBetweenStationsDTO>>> FindRoutesBetweenStations(int depStation, int arrStation, DateTime depaturedate);

    }
}
