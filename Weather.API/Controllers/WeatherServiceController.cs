using Microsoft.AspNetCore.Mvc;
using Weather.BLL.Constants.Resources;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.BLL.Services.IService;
using Weather.BLL.DTOs;
using Weather.BLL.DTOs.FiveDayWeatherDTOs;

namespace Weather.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherServiceController : ControllerBase
    {
        #region Weather Service Controller Constructors
        
        private readonly ILogger<WeatherServiceController> _logger;
        private readonly IWeatherForecastService _weatherService;
        private readonly ICustomWeatherService _customWeatherService;

        public WeatherServiceController(ILogger<WeatherServiceController> logger, IWeatherForecastService weatherService, ICustomWeatherService customWeatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
            _customWeatherService = customWeatherService;
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

        //Get Action Method - Five Days Forecast
        [HttpGet, Route("fivedays-forecast")]
        public async Task<ActionResult<List<FiveDayWeatherDto>>> FiveDaysForecast(string location, string unit, CancellationToken cancellationToken)
        {
            try
            {
                var fivedayWeather = await _customWeatherService.FiveDayWeather(location, unit, cancellationToken);
                return await Task.Run(() => Ok(fivedayWeather));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return BadRequest($"{ErrorMessages.GeneralError}:{ex}");
            }
        }


        //Get Action Method - Five Days Forecast / 3 Hour Interval
        [HttpGet, Route("fivedays-hourly-forecast")]
        public async Task<ActionResult<List<WeatherClientResponseDto>>> FiveDaysHourlyForecast(string location, string unit, CancellationToken cancellationToken)
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
