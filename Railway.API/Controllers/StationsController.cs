using Microsoft.AspNetCore.Mvc;
using Railway.Application.Services.Stations;
using Railway.Shared.Core;
using Railway.Shared.DTOs;
using Railway.Shared.Requests;

namespace Railway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpPost("schedule")]
        public async Task<IActionResult> GetSchedule([FromBody] StationScheduleRequest request)
        {
            var result = await _stationService.GetStationScheduleForDay(request.StationId, request.ScheduleDate);

            if (!result.IsSuccess)
                return BadRequest(result.Error.Message);

            return Ok(result.Value);
        }

        [HttpGet("route-schedule")]
        public async Task<ActionResult<List<StationForRouteDTO>>> GetStationScheduleForRoute(
    [FromQuery] int? stationId,
    [FromQuery] bool isArrival)
        {
            var result = await _stationService.GetStationScheduleForRoute(stationId, isArrival);

            if (!result.IsSuccess)
                return BadRequest(result.Value);

            return Ok(result.Value);
        }
    }
}
