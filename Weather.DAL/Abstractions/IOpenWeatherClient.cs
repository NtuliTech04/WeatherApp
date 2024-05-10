using FluentResults;
using Weather.DAL.Data.WeatherAPIResponse;

namespace Weather.DAL.Abstractions
{
    public interface IOpenWeatherClient
    {
        Task<Result<WeatherResponseData>> GetFiveDayForecast(string location, string unit);
    }
}
