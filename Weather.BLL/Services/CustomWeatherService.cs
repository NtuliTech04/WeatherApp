using AutoMapper;
using Weather.BLL.DTOs.FiveDayWeatherDTOs;
using Weather.BLL.Interfaces;
using Weather.BLL.Interfaces.Repositories;
using Weather.BLL.Services.IService;

namespace Weather.BLL.Services
{
    internal sealed class CustomWeatherService : ICustomWeatherService
    {
        #region Custome Weather Service Constructors

        private readonly ICustomWeatherRepository _repository;
        private readonly IWeatherForecastService _forecastService;
        private IMapper _mapper;

        public CustomWeatherService(ICustomWeatherRepository repository, IWeatherForecastService forecastService, IMapper mapper)
        {
            _repository = repository;
            _forecastService = forecastService;
            _mapper = mapper;
        }

        #endregion

        public async Task<List<FiveDayWeatherDto>> FiveDayWeather(string location, string unit, CancellationToken cancellationToken)
        {
            var forecastResult = await _forecastService.GetFiveDayForecast(location, unit, cancellationToken);
            var forecastList = _mapper.Map<List<FiveDayWeatherDto>>(forecastResult);

            //Convert timestamps and assign result to date 
            foreach (var forecast in forecastList)
            {
                forecast.WeatherDate = DateTimeOffset.FromUnixTimeSeconds(forecast.Timestamp).DateTime.Date;
            }

            //Applies processing logic from the function and returns results
            List<FiveDayWeatherDto> fiveDayWeathers = await _repository.GetFiveDayWeather(forecastList);

            return await Task.Run(() => fiveDayWeathers);
        }
    }
}