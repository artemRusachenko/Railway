using Railway.Domain.Passengers;
using Railway.Shared.Core;
using Railway.Shared.DTOs;

namespace Railway.Application.Services.Tickets
{
    public interface ITicketsService
    {
        public Task<Result<List<PassengerTicketDTO>>> GetPassengerTickets(int passengerId);
        public Task<Result<bool>> AddTicket(string firstName, string lastName, int seatId, int depatureStationId, int arrivalStationId);
        Task<Result<Passenger>> GetPassengerByNameAsync(string firstName, string lastName);


    }
}
