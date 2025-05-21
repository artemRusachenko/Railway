using Railway.Domain.Routes;
using Railway.Shared.Core;
using Railway.Shared.DTOs;

namespace Railway.Application.Services
{
    public class RouteService : IRouteSercvice
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<Result<List<RouteBetweenStationsDTO>>> FindRoutesBetweenStations(int depStation, int arrStation, DateTime depaturedate)
        {
            try
            {
                var routes = await _routeRepository.GetRoutesBetweenStations(depStation, arrStation, depaturedate);

                var routeDtos = routes.Select(r => new RouteBetweenStationsDTO
                {
                    TrainId = r.TrainId,
                    TrainNumber = r.TrainNumber,
                    RouteName = r.RouteName,
                    DepatureDateTime = r.DepartureDateTime,
                    ArrivalDateTime = r.ArrivalDateTime,
                    DepatureStationName = r.DepartureStationName,
                    ArrivalStationName = r.ArrivalStationName,
                    ArrivalStationId = r.ArrivalStationId,
                    DepatureStationId = r.DepatureStationId,
                }).ToList();

                return ResultBuilder.Success(routeDtos);
            }
            catch (Exception ex)
            {
                return ResultBuilder.Failure<List<RouteBetweenStationsDTO>>(ex);
            }
        }
    }
}
