using FluentValidation;
using Microsoft.Extensions.Options;
using Weather.DAL.Abstractions;
using Weather.DAL.Configurations;
using Ardalis.GuardClauses;
using FluentResults;
using Weather.DAL.Data.WeatherAPIResponse;
using Newtonsoft.Json;


namespace Weather.DAL.Repositories
{
    internal sealed class OpenWeatherClient : IOpenWeatherClient
    {
        private readonly HttpClient _httpClient;
        private readonly OpenWeather _openWeatherConfig;
        private readonly IJsonSerializerSettingsFactory _jsonSerializerSettingsFactory;

        public OpenWeatherClient
            (
                IHttpClientFactory httpClientFactory,
                IOptions<OpenWeather> options,
                IValidator<OpenWeather> optionsValidator,
                IJsonSerializerSettingsFactory jsonSerializerSettingsFactory
            )
        {
            _openWeatherConfig = options.Value;
            Guard.Against.Null(httpClientFactory);
            _httpClient = httpClientFactory.CreateClient();
            _jsonSerializerSettingsFactory = Guard.Against.Null(jsonSerializerSettingsFactory);
        }

        public async Task<Result<WeatherResponseData>> GetFiveDayForecast(string location, string unit)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(BuildOpenWeatherUrl(location, unit))
            };

            return await SendAsyncSave<WeatherResponseData>(request);
        }

        private async Task<Result<T>> SendAsyncSave<T>(HttpRequestMessage requestMessage )
        {
            try
            {
                return await SendAsync<T>(requestMessage);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }


        private async Task<Result<T>> SendAsync<T>(HttpRequestMessage requestMessage)
        {
            using var response = await _httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                return Result.Fail($"Failed response to {nameof(SendAsync)}");
            }

            var resultContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(resultContent, _jsonSerializerSettingsFactory.Create());
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
