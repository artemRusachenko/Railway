using Microsoft.AspNetCore.Mvc;
using Railway.Application.Services.Seats;
using Railway.Shared.DTOs;
using Railway.Shared.Requests;

namespace Railway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpPost("by-carriage")]
        public async Task<IActionResult> GetSeatsByCarriageId([FromBody] SeatRequest request)
        {
            var result = await _seatService.GetSeatsByCarriageId(
                request.TrainId,
                request.CarriageId,
                request.DepartureStationId,
                request.ArrivalStationId);

            if (!result.IsSuccess)
                return BadRequest(result.Error.Message);

            return Ok(result.Value);
        }
    }
}
