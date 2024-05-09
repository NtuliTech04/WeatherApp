using FluentResults;
using OpenWeatherMap.Client.DTOs.WeatherResponse;

namespace OpenWeatherMap.Client.Abstractions
{
    public interface IOpenWeatherClient
    {
        Task<Result<WeatherResponseDataDto>> GetFiveDayForecast(string location, string unit);
    }
}
