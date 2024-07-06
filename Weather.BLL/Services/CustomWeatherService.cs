using AutoMapper;
using Weather.BLL.Abstractions;
using Weather.BLL.DTOs;
using Weather.BLL.DTOs.FiveDayWeatherDTOs;
using Weather.BLL.Services.IService;

namespace Weather.BLL.Services
{
    internal sealed class CustomWeatherService : ICustomWeatherService
    {
        #region Custome Weather Service Constructors

        private readonly ICustomWeatherRepository _repository;
        private readonly IWeatherForecastService _forecastService;
        private readonly IDateTimeService _dateTimeService;
        private IMapper _mapper;

        public CustomWeatherService(ICustomWeatherRepository repository, IWeatherForecastService forecastService, IDateTimeService dateTimeService, IMapper mapper)
        {

            _repository = repository;
            _forecastService = forecastService;
            _dateTimeService = dateTimeService;
            _mapper = mapper;
        }

        #endregion

        public async Task<List<FiveDayWeatherDto>> FiveDayWeather(UrlOptionsDto options, CancellationToken cancellationToken)
        {
            var forecastResult = await _forecastService.GetFiveDayForecast(options, cancellationToken);
            var forecastList = _mapper.Map<List<FiveDayWeatherDto>>(forecastResult.WeatherForecastDataDto);

            //Convert timestamps and assign result to date 
            foreach (var forecast in forecastList)
            {
                forecast.WeatherDate = _dateTimeService.GetHumanDate(forecast.Timestamp).Date;
            }

            //Applies processing logic from the function and returns results
            List<FiveDayWeatherDto> fiveDayWeathers = await _repository.GetFiveDayWeather(forecastList);

            return await Task.Run(() => fiveDayWeathers);
        }
    }
}