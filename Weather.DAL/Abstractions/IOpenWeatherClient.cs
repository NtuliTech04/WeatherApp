using FluentResults;
using Weather.DAL.Data.WeatherClientResponse;

namespace Weather.DAL.Abstractions
{
    public interface IOpenWeatherClient
    {
        Task<Result<WeatherClientResponse>> CurrentForecastResponse(string location, string unit, CancellationToken cancellationToken);

        Task<Result<WeatherClientResponseData>> FiveDayForecastResponse(string location, string unit, CancellationToken cancellationToken);
    }
}
