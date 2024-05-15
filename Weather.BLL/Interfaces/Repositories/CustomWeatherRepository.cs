using Weather.BLL.DTOs.FiveDayWeatherDTOs;

namespace Weather.BLL.Interfaces.Repositories
{
    public class CustomWeatherRepository : ICustomWeatherRepository
    {
        public async Task<List<FiveDayWeatherDto>> GetFiveDayWeather(List<FiveDayWeatherDto> forecastList)
        {
            //Groups five day hourly forecast data by date/day.
            IEnumerable<IGrouping<DateTime, FiveDayWeatherDto>> fiveDayHourlyGroupedForecast = forecastList.GroupBy(date => date.WeatherDate.Date);

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
            return await Task.Run(() => fiveDayForecast);
        }
    }
}
