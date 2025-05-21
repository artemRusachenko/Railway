using Microsoft.AspNetCore.Mvc;
using Railway.Application.Services.Trains;

namespace Railway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService _trainService;

        public TrainController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpGet("carriages")]
        public async Task<IActionResult> GetCarriagesInfo([FromQuery] int trainId, [FromQuery] int departureStationId, [FromQuery] int arrivalStationId)
        {
            var result = await _trainService.GetTrainCarriagesInfo(trainId, departureStationId, arrivalStationId);

            if (!result.IsSuccess)
                return NotFound(result.Error.Message);

            return Ok(result.Value);
        }
    }
}
