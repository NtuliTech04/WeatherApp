using Microsoft.AspNetCore.Mvc;
using Weather.BLL.DTOs;
using Weather.BLL.Services.IService;

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
        public async Task<ActionResult<List<WeatherResponseDto>>> GetForecast(string location, string unit)
        {
            return await Task.Run(() => Ok(_weatherService.GetWeatherForecast(location, unit)));
        }
    }
}
