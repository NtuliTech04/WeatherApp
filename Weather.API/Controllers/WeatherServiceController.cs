﻿using Microsoft.AspNetCore.Mvc;
using Weather.BLL.Constants.Resources;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.BLL.Services.IService;
using Weather.BLL.DTOs.FiveDayWeatherDTOs;
using Weather.BLL.DTOs.CurrentForecastDTOs;
using Weather.BLL.DTOs;

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
        [HttpGet, Route("current")]
        public async Task<ActionResult<CurrentForecastDto>> CurrentWeather([FromQuery] UrlOptionsDto options, CancellationToken cancellationToken)
        {
            try
            {
                var weatherNow = await _weatherService.GetCurrentForecast(options, cancellationToken);
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
        public async Task<ActionResult<List<FiveDayWeatherDto>>> FiveDaysForecast([FromQuery] UrlOptionsDto options, CancellationToken cancellationToken)
        {
            try
            {
                var fivedayWeather = await _customWeatherService.FiveDayWeather(options, cancellationToken);
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
        public async Task<ActionResult<List<WeatherClientResponseDataDto>>> FiveDaysHourlyForecast([FromQuery] UrlOptionsDto options, CancellationToken cancellationToken)
        {
            try
            {
                var forecast = await _weatherService.GetFiveDayForecast(options, cancellationToken);
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
