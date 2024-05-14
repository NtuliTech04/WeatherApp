using Microsoft.AspNetCore.Mvc;
using Weather.BLL.Utilities.Exceptions;
using Weather.BLL.Constants.Resources;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.BLL.Services.IService;
using Weather.BLL.DTOs.CurrentForecastDtos;

namespace Weather.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherServiceController : ControllerBase
    {
        private readonly ILogger<WeatherServiceController> _logger;
        private readonly IWeatherForecastService _weatherService;

        public WeatherServiceController(ILogger<WeatherServiceController> logger, IWeatherForecastService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet, Route("current-weather")]
        public async Task<ActionResult<CurrentForecastDto>> CurrentWeather(string location, string unit, CancellationToken cancellationToken)
        {
            try
            {
                var weatherNow = await _weatherService.GetCurrentForecast(location, unit, cancellationToken);
                return await Task.Run(() => Ok(weatherNow));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return BadRequest($"{ErrorMessages.GeneralError}:{ex}");
            }
        }

        [HttpGet, Route("fivedays-weather")]
        public async Task<ActionResult<List<WeatherClientResponseDto>>> FiveDaysWeather(string location, string unit, CancellationToken cancellationToken)
        {
            try
            {
                var forecast = await _weatherService.GetFiveDayForecast(location, unit, cancellationToken);
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
