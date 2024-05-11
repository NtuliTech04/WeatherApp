using Microsoft.AspNetCore.Mvc;
using Weather.BLL.DTOs;
using Weather.BLL.Services.IService;
using Weather.BLL.Utilities.Exceptions;
using Weather.BLL.Constants.Resources;

namespace Weather.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherServiceController : ControllerBase
    {
        private readonly ILogger<WeatherServiceController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherServiceController(ILogger<WeatherServiceController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet, Route("weather-forecast")]
        public async Task<ActionResult<List<WeatherClientResponseDto>>> GetForecast(string location, string unit)
        {
            try
            {
                var forecast = _weatherService.GetWeatherForecast(location, unit);
                return await Task.Run(() => Ok(forecast));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return BadRequest($"{ErrorMessages.GeneralError}:{ex}");
            }
        }
    }
}
