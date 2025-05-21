using Microsoft.AspNetCore.Mvc;
using Railway.Application.Services.Tickets;
using Railway.Shared.Requests;

namespace Railway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [HttpGet("passenger/by-name")]
        public async Task<IActionResult> GetTicketsByPassengerName([FromQuery] string firstName, [FromQuery] string lastName)
        {
            var passengerResult = await _ticketsService.GetPassengerByNameAsync(firstName, lastName);
            if (!passengerResult.IsSuccess)
                return NotFound($"Пасажира з ім'ям {firstName} {lastName} не знайдено");

            int passengerId = passengerResult.Value.Id;

            var ticketsResult = await _ticketsService.GetPassengerTickets(passengerId);
            if (ticketsResult.IsSuccess)
                return Ok(ticketsResult.Value);

            return BadRequest(ticketsResult.Error.Message);
        }


        [HttpGet("passenger/{passengerId}")]
        public async Task<IActionResult> GetTicketsForPassenger(int passengerId)
        {
            var result = await _ticketsService.GetPassengerTickets(passengerId);
            if (result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(result.Error.Message);
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyTicket([FromBody] BuyTicketRequest request)
        {
            var result = await _ticketsService.AddTicket(
                request.FirstName,
                request.LastName,
                request.SeatId,
                request.DepartureStationId,
                request.ArrivalStationId);

            if (result.IsSuccess)
                return Ok(new { Message = "Ticket purchased successfully." });

            return BadRequest(result.Error.Message);
        }
    }
}
