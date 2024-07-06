using FluentResults;
using Weather.DAL.Data.CurrentWeatherResponse;
using Weather.DAL.Data.WeatherClientResponse;
using Weather.DAL.Models;

namespace Weather.DAL.Abstractions
{
    public interface IOpenWeatherClient
    {
        Task<Result<CurrentWeatherResponse>> CurrentForecastResponse(UrlOptions options, CancellationToken cancellationToken);

        Task<Result<WeatherClientResponseData>> FiveDayForecastResponse(UrlOptions options, CancellationToken cancellationToken);
    }
}
