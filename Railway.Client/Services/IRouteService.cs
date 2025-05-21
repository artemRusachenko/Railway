using Railway.Shared.DTOs;
using Railway.Shared.Requests;

namespace Railway.Client.Services
{
    public interface IRouteService
    {
        Task<List<RouteBetweenStationsDTO>?> SearchRoutesAsync(RouteSearchRequest request);
        Task<List<StationForRouteDTO>> GetStationsForRouteAsync(int? stationId, bool isArrival);
        Task<List<TrainCarriagesDTO>> GetCarriagesInfoAsync(int trainId, int departureStationId, int arrivalStationId);
        Task<List<SeatInfoDTO>> GetSeatsByCarriageAsync(SeatRequest request);
        Task<bool> BuyTicketAsync(BuyTicketRequest request);
        Task<List<PassengerTicketDTO>> GetTicketsByNameAsync(string firstName, string lastName);
        Task<List<StationScheduleForDayDTO>> GetStationScheduleForDayAsync(StationScheduleRequest request);

    }
}
