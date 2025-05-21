using Railway.Domain.Passengers;
using Railway.Domain.Tickets;
using Railway.Shared.Core;
using Railway.Shared.DTOs;

namespace Railway.Application.Services.Tickets
{
    public class TicketsService : ITicketsService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IPassengerRepository _passengerRepository;

        public TicketsService(ITicketRepository ticketRepository, IPassengerRepository passengerRepository)
        {
            _ticketRepository = ticketRepository;
            _passengerRepository = passengerRepository;
        }

        public async Task<Result<bool>> AddTicket(string firstName, string lastName, int seatId, int depatureStationId, int arrivalStationId)
        {
            try
            {
                var passenger = await _passengerRepository.GetByNameAsync(firstName, lastName);
                if (passenger == null)
                {
                    passenger = await _passengerRepository.AddAsync(firstName, lastName);
                }

                var ticketAdded = await _ticketRepository.AddTicket(passenger.Id, seatId, depatureStationId, arrivalStationId);

                if (ticketAdded)
                {
                    return ResultBuilder.Success(true);
                }
                else
                {
                    return ResultBuilder.Failure<bool>(new Exception("Failed to add ticket"));
                }
            }
            catch (Exception ex)
            {
                return ResultBuilder.Failure<bool>(ex);
            }
        }

        public async Task<Result<Passenger>> GetPassengerByNameAsync(string firstName, string lastName)
        {
            try
            {
                var passenger = await _passengerRepository.GetByNameAsync(firstName, lastName);
                if (passenger == null)
                    return ResultBuilder.Failure<Passenger>(new Exception("Passenger not found"));

                return ResultBuilder.Success(passenger);
            }
            catch (Exception ex)
            {
                return ResultBuilder.Failure<Passenger>(ex);
            }
        }


        public async Task<Result<List<PassengerTicketDTO>>> GetPassengerTickets(int passengerId)
        {
            try
            {
                var results = await _ticketRepository.GetPessangerTickets(passengerId);

                var dtos = results.Select(r => new PassengerTicketDTO
                {
                    TicketId = r.TicketId,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    TrainNumber = r.TrainNumber,
                    SeatNumber = r.SeatNumber,
                    CarriageNumber = r.CarriageNumber,
                    CarriageType = r.CarriageType,
                    FromDateTime = r.FromDateTime,
                    DepatureStation = r.DepartureStation,
                    ToDateTime = r.ToDateTime,
                    ArrivalStation = r.ArrivalStation
                }).ToList();

                return ResultBuilder.Success(dtos);
            }
            catch (Exception ex)
            {
                return ResultBuilder.Failure<List<PassengerTicketDTO>>(ex);
            }
        }


    }
}
