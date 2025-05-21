using Microsoft.AspNetCore.Mvc;
using Railway.Application.Services;
using Railway.Shared.Requests;

namespace Railway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteSercvice _routeService;

        public RoutesController(IRouteSercvice routeService)
        {
            _routeService = routeService;
        }

        [HttpPost("between-stations")]
        public async Task<IActionResult> GetRoutesBetweenStations([FromBody] RouteSearchRequest request)
        {
            var result = await _routeService.FindRoutesBetweenStations(request.DepStation, request.ArrStation, request.DepatureDate);
            if (!result.IsSuccess)
                return StatusCode(500, result.Error?.Message);

            return Ok(result.Value);
        }
    }
}
