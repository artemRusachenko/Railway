using System.Net.Http.Json;
using Railway.Shared.DTOs;
using Railway.Shared.Requests;
using static System.Net.WebRequestMethods;

namespace Railway.Client.Services
{
    public class RouteService : IRouteService
    {
        private readonly HttpClient _httpClient;

        public RouteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RouteBetweenStationsDTO>?> SearchRoutesAsync(RouteSearchRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/routes/between-stations", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<RouteBetweenStationsDTO>>();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<StationForRouteDTO>> GetStationsForRouteAsync(int? stationId, bool isArrival)
        {
            // Формируем query string параметры (если stationId == null, не передаем его)
            var queryParams = new List<string>();

            if (stationId.HasValue)
                queryParams.Add($"stationId={stationId.Value}");

            queryParams.Add($"isArrival={isArrival}");

            var queryString = string.Join('&', queryParams);

            var url = $"api/station/route-schedule?{queryString}";

            // Запрос к API, возвращаем список DTO
            var stations = await _httpClient.GetFromJsonAsync<List<StationForRouteDTO>>(url);

            return stations ?? new List<StationForRouteDTO>();
        }

        public async Task<List<TrainCarriagesDTO>> GetCarriagesInfoAsync(int trainId, int departureStationId, int arrivalStationId)
        {
            var response = await _httpClient.GetAsync($"api/train/carriages?trainId={trainId}&departureStationId={departureStationId}&arrivalStationId={arrivalStationId}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<TrainCarriagesDTO>>();
                return result ?? new();
            }

            return new();
        }

        public async Task<List<SeatInfoDTO>> GetSeatsByCarriageAsync(SeatRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/seats/by-carriage", request);

            if (!response.IsSuccessStatusCode)
                return new List<SeatInfoDTO>();

            return await response.Content.ReadFromJsonAsync<List<SeatInfoDTO>>() ?? new List<SeatInfoDTO>();
        }

        public async Task<bool> BuyTicketAsync(BuyTicketRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/tickets/buy", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<PassengerTicketDTO>> GetTicketsByNameAsync(string firstName, string lastName)
        {
            var response = await _httpClient.GetAsync($"api/tickets/passenger/by-name?firstName={firstName}&lastName={lastName}");

            if (response.IsSuccessStatusCode)
            {
                var tickets = await response.Content.ReadFromJsonAsync<List<PassengerTicketDTO>>();
                return tickets ?? new List<PassengerTicketDTO>();
            }

            return new List<PassengerTicketDTO>();
        }

        public async Task<List<StationScheduleForDayDTO>> GetStationScheduleForDayAsync(StationScheduleRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/station/schedule", request);
            response.EnsureSuccessStatusCode();

            var schedule = await response.Content.ReadFromJsonAsync<List<StationScheduleForDayDTO>>();
            return schedule ?? new List<StationScheduleForDayDTO>();
        }
    }
}
