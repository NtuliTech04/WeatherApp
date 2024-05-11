using FluentResults;
using Weather.DAL.Data.WeatherClientResponse;

namespace Weather.DAL.Abstractions
{
    public interface IOpenWeatherClient
    {
        Result<WeatherClientResponseData> GetFiveDayForecast(string location, string unit);
    }
}
