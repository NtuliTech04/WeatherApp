using Microsoft.AspNetCore.Mvc;
using Weather.BLL.Utilities.Exceptions;
using Weather.BLL.Constants.Resources;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.BLL.Services.IService;
using Weather.BLL.DTOs;

namespace Weather.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherServiceController : ControllerBase
    {
        #region Weather Service Controller Constructers
        
        private readonly ILogger<WeatherServiceController> _logger;
        private readonly IWeatherForecastService _weatherService;

        public WeatherServiceController(ILogger<WeatherServiceController> logger, IWeatherForecastService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }
        
        #endregion


        //Get Action Method - Weather Now
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



        //Get Action Method - Five Days Forecast / 3 Hour Interval
        [HttpGet, Route("fivedays-forecast")]
        public async Task<ActionResult<List<WeatherClientResponseDto>>> FiveDaysForecast(string location, string unit, CancellationToken cancellationToken)
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
