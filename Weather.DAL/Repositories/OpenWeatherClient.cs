using FluentValidation;
using Microsoft.Extensions.Options;
using Weather.DAL.Abstractions;
using Weather.DAL.Configurations;
using Ardalis.GuardClauses;
using FluentResults;
using System.Text.Json;
using Weather.DAL.Data.WeatherClientResponse;

namespace Weather.DAL.Repositories
{
    internal sealed class OpenWeatherClient : IOpenWeatherClient
    {
        #region Open Weather Client Constructors

        private enum WeatherResource { weather, forecast }

        private readonly HttpClient _httpClient;
        private readonly OpenWeather _openWeatherConfig;

        public OpenWeatherClient ( IOptions<OpenWeather> options, IHttpClientFactory httpClientFactory )
        {
            _openWeatherConfig = options.Value;
            Guard.Against.Null(httpClientFactory);
            _httpClient = httpClientFactory.CreateClient();
        }

        #endregion

        public async Task<Result<WeatherClientResponse>> CurrentForecastResponse(string location, string unit, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(OpenWeatherUrlBuilder(WeatherResource.weather.ToString(), location, unit))
            };

            var currentWeatherResults = await SendSaveAsync<WeatherClientResponse>(request, cancellationToken);

            return currentWeatherResults;
        }

        public async Task<Result<WeatherClientResponseData>> FiveDayForecastResponse(string location, string unit, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(OpenWeatherUrlBuilder(WeatherResource.forecast.ToString(), location, unit))
            };

            var fiveDayWeatherResults = await SendSaveAsync<WeatherClientResponseData>(request, cancellationToken);

            return fiveDayWeatherResults;
        }

        private async Task<Result<T>> SendSaveAsync<T>(HttpRequestMessage requestMessage, CancellationToken cancellationToken )
        {
            try
            {
                return await SendAsync<T>(requestMessage, cancellationToken);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<Result<T>> SendAsync<T>(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
        {
            using var response = await _httpClient.SendAsync(requestMessage, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return Result.Fail($"Failed response to {nameof(SendAsync)}");
            }   

            var resultContent = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<T>(resultContent);

            if (result is null)
            {
                return Result.Fail($"Failed to deserialize response.");
            }

            return Result.Ok(result);
        }

        private string OpenWeatherUrlBuilder(string resource, string location, string unit)
        {
            return $"https://api.openweathermap.org/data/2.5/{resource}?q=" +
                   $"{location}," +
                   $"{"za"}" +
                   $"&appid={_openWeatherConfig.ApiKey}" +
                   $"&units={unit}";

            #region Old Open Weather URL
            //$"https://api.openweathermap.org/data/2.5/forecast" +
            //$"?appid={_openWeatherConfig.ApiKey}" +
            //$"&q={location}" +
            //$"&units={unit}";
            #endregion
        }
    }
}
