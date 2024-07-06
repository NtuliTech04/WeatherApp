using Weather.BLL.DTOs.FiveDayWeatherDTOs;

namespace Weather.BLL.Abstractions.Repositories
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
                var dayHourlyTemps = new List<decimal>();
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
                        var minTemp = dayHourlyTemps.Min();
                        var maxTemp = dayHourlyTemps.Max();

                        //Gets forecast record corresponding with the max temp for the day.
                        var recordToAdd = dayHourlyGroupedForecast.FirstOrDefault(x => x.FiveDayTemps.Temp == maxTemp);

                        //Add min & max temps for the day
                        recordToAdd.MinDayTemp = minTemp;
                        recordToAdd.MaxDayTemp = maxTemp;

                        fiveDayForecast.Add(recordToAdd);
                    }
                }
            }
            return await Task.Run(() => fiveDayForecast);
        }
    }
}
