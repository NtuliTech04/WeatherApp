using FluentResults;
using Weather.DAL.Data.CurrentWeatherResponse;
using Weather.DAL.Data.WeatherClientResponse;

namespace Weather.DAL.Abstractions
{
    public interface IOpenWeatherClient
    {
        Task<Result<CurrentWeatherResponse>> CurrentForecastResponse(string location, string unit, CancellationToken cancellationToken);

        Task<Result<WeatherClientResponseData>> FiveDayForecastResponse(string location, string unit, CancellationToken cancellationToken);
    }
}
