using AutoMapper;
using Weather.BLL.DTOs.FiveDayWeatherDTOs;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.BLL.Services.IService;
using Weather.DAL.Abstractions;

namespace Weather.BLL.Services
{
    internal sealed class CustomWeatherService : ICustomWeatherService
    {
        #region Custome Weather Service Constructors

        private readonly IOpenWeatherClient _openWeatherClient;
        private readonly IWeatherForecastService _forecastService;
        private IMapper _mapper;

        public CustomWeatherService(IOpenWeatherClient openWeatherClient, IWeatherForecastService forecastService, IMapper mapper)
        {
            _openWeatherClient = openWeatherClient;
            _forecastService = forecastService;
            _mapper = mapper;
        }

        #endregion

        public async Task<List<FiveDayWeatherDto>> GetFiveDayWeather(string location, string unit, CancellationToken cancellationToken)
        {
            var forecastResult = await _forecastService.GetFiveDayForecast(location, unit, cancellationToken);
            var forecastList = _mapper.Map<List<FiveDayWeatherDto>>(forecastResult);

            //Convert timestamps and assign result to date 
            foreach (var forecast in forecastList)
            {
                forecast.WeatherDate = DateTimeOffset.FromUnixTimeSeconds(forecast.Timestamp).DateTime.Date;
            }

            //Applies processing logic from the function and returns results
            List<FiveDayWeatherDto> fiveDayWeathers = FiveDayWeather(forecastList);

            return await Task.Run(() => fiveDayWeathers);
        }


        #region Custom Weather Service Helper Functions

        private static IEnumerable<IGrouping<DateTime, FiveDayWeatherDto>> GroupForecastDataByDate(List<FiveDayWeatherDto> forecastList)
        {
            var fiveDayHourlyGroupedForecast = forecastList.GroupBy(date => date.WeatherDate.Date);

            return fiveDayHourlyGroupedForecast;
        }

        private List<FiveDayWeatherDto> FiveDayWeather(List<FiveDayWeatherDto> forecastList)
        {
            //Groups five day hourly forecast data by date/day.
            IEnumerable<IGrouping<DateTime, FiveDayWeatherDto>> fiveDayHourlyGroupedForecast = GroupForecastDataByDate(forecastList);

            var fiveDayForecast = new List<FiveDayWeatherDto>();

            //Getting Min & Max Temperature for each day and listing each record.
            foreach (var dayHourlyGroupedForecast in fiveDayHourlyGroupedForecast)
            {
                //Holds hourly temperatures for the day
                var dayHourlyTemps = new List<Decimal>();
                int count = 0;

                //Targets hourly forecast results for one day 
                foreach (var hourlyGroupedForecast in dayHourlyGroupedForecast)
                {
                    while (count < dayHourlyGroupedForecast.Count())
                    {
                        //Extracts temps from one day hourly forecasts
                        dayHourlyTemps.Add(hourlyGroupedForecast.FiveDayTemps.Temp);
                        count++;

                        break;
                    }

                    //When done, then get Min & max, and add to list.
                    if (count == dayHourlyGroupedForecast.Count())
                    {
                        hourlyGroupedForecast.MinDayTemp = dayHourlyTemps.Min();
                        hourlyGroupedForecast.MaxDayTemp = dayHourlyTemps.Max();

                        fiveDayForecast.Add(hourlyGroupedForecast);
                    }
                }
            }
            return fiveDayForecast;
        }

        #endregion
    }
}