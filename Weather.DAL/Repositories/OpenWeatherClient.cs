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
        private readonly HttpClient _httpClient;
        private readonly OpenWeather _openWeatherConfig;

        public OpenWeatherClient
            (
                IOptions<OpenWeather> options,
                IHttpClientFactory httpClientFactory
            )
        {
            _openWeatherConfig = options.Value;
            Guard.Against.Null(httpClientFactory);
            _httpClient = httpClientFactory.CreateClient();
        }

        public Result<WeatherClientResponseData> GetFiveDayForecast(string location, string unit)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(BuildOpenWeatherUrl(location, unit))
            };

            var apiClientResults = SendSave<WeatherClientResponseData>(request);

            return apiClientResults;
        }

        private Result<T> SendSave<T>(HttpRequestMessage requestMessage )
        {
            try
            {
                return Send<T>(requestMessage);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }


        private Result<T> Send<T>(HttpRequestMessage requestMessage)
        {
            using var response = _httpClient.Send(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                return Result.Fail($"Failed response to {nameof(Send)}");
            }

            var resultContent = response.Content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<T>(resultContent);

            if (result is null)
            {
                return Result.Fail($"Failed to deserialize response.");
            }

            return Result.Ok(result);
        }

        private string BuildOpenWeatherUrl(string location, string unit)
        {
            return $"https://api.openweathermap.org/data/2.5/forecast" +
                   $"?appid={_openWeatherConfig.ApiKey}" +
                   $"&q={location}" +
                   $"&units={unit}";
        }
    }
}
