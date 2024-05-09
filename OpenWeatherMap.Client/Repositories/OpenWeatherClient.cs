using FluentValidation;
using Microsoft.Extensions.Options;
using OpenWeatherMap.Client.Abstractions;
using OpenWeatherMap.Client.Options;
using Ardalis.GuardClauses;
using FluentResults;
using OpenWeatherMap.Client.DTOs.WeatherResponse;
using Newtonsoft.Json;


namespace OpenWeatherMap.Client.Repositories
{
    internal sealed class OpenWeatherClient : IOpenWeatherClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<OpenWeatherOptions> _configOptions;
        private readonly OpenWeatherOptions _openWeatherConfig;
        private readonly IJsonSerializerSettingsFactory _jsonSerializerSettingsFactory;

        public OpenWeatherClient
            (
                IOptions<OpenWeatherOptions> options,
                IHttpClientFactory httpClientFactory,
                IValidator<OpenWeatherOptions> optionsValidator,
                IJsonSerializerSettingsFactory jsonSerializerSettingsFactory
            )
        {
            Guard.Against.Null(httpClientFactory);
            _httpClient = httpClientFactory.CreateClient();
            _configOptions = Guard.Against.Null(options);
            _openWeatherConfig = options.Value;
            _jsonSerializerSettingsFactory = Guard.Against.Null(jsonSerializerSettingsFactory);

            ValidateOptions(optionsValidator, options);
        }

        private static void ValidateOptions(IValidator<OpenWeatherOptions> optionsValidator, IOptions<OpenWeatherOptions> options)
        {
            var validationResult = optionsValidator.Validate(options.Value);

            if (validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid {nameof(OpenWeatherOptions)}: {validationResult}");
            }
        }


        public async Task<Result<WeatherResponseDataDto>> GetFiveDayForecast(string location, string unit)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(BuildOpenWeatherUrl("forecast", location, unit))
            };

            return await SendAsyncSave<WeatherResponseDataDto>(request);
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


        private string BuildOpenWeatherUrl(string resource, string location, string unit)
        {
            return $"https://api.openweathermap.org/data/2.5/{resource}" +
                   $"?appid={_openWeatherConfig.ApiKey}" +
                   $"&q={location}" +
                   $"&units={unit}";
        }
    }
}
