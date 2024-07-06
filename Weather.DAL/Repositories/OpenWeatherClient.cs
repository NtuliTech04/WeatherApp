using FluentValidation;
using Microsoft.Extensions.Options;
using Weather.DAL.Abstractions;
using Ardalis.GuardClauses;
using FluentResults;
using System.Text.Json;
using Weather.DAL.Data.WeatherClientResponse;
using Weather.DAL.Data.CurrentWeatherResponse;
using Weather.BLL.Constants.Enums;
using Weather.DAL.Models;
using Weather.DAL.Configurations.ValueObjects;

namespace Weather.DAL.Repositories
{
    internal sealed class OpenWeatherClient : IOpenWeatherClient
    {
        #region Open Weather Client Constructors

        private readonly HttpClient _httpClient;
        private readonly OpenWeather _openWeatherConfig;

        public OpenWeatherClient ( IOptions<OpenWeather> options, IHttpClientFactory httpClientFactory )
        {
            _openWeatherConfig = options.Value;
            Guard.Against.Null(httpClientFactory);
            _httpClient = httpClientFactory.CreateClient();
        }

        #endregion

        //Gets the current forecast from the weather API
        public async Task<Result<CurrentWeatherResponse>> CurrentForecastResponse(UrlOptions options, CancellationToken cancellationToken)
        {
            //Creates a new instance of an http request message class and initializes its properties 
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(OpenWeatherUrlBuilder(WeatherResource.weather.ToString(), options))
            };


            //Sends the new instance of http request message to the handling method
            var currentWeatherResults = await SendRequestAsync<CurrentWeatherResponse>(request, cancellationToken);

            return currentWeatherResults;
        }

        //Gets a five day/3 hourly forecast from the weather API
        public async Task<Result<WeatherClientResponseData>> FiveDayForecastResponse(UrlOptions options, CancellationToken cancellationToken)
        {
            //Creates a new instance of an http request message class and initializes its properties 
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(OpenWeatherUrlBuilder(WeatherResource.forecast.ToString(), options))
            };

            //Sends the new instance of http request message to the handling method
            var fiveDayWeatherResults = await SendRequestAsync<WeatherClientResponseData>(request, cancellationToken);

            return fiveDayWeatherResults;
        }



        //Exception handler when sending http request messages
        private async Task<Result<T>> SendRequestAsync<T>(HttpRequestMessage requestMessage, CancellationToken cancellationToken )
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

        //Sends http requests to the weather service API and deserializes the response/result
        private async Task<Result<T>> SendAsync<T>(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
        {
            //Uses the http client to send a get request to the weather service API using the URI in the HttpRequestMessage
            using var response = await _httpClient.SendAsync(requestMessage, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return Result.Fail($"Failed response to {nameof(SendAsync)}");
            }   

            //Reads response content as a string data
            var resultContent = await response.Content.ReadAsStringAsync();

            //Converts that string data into json results by deserializing
            var result = JsonSerializer.Deserialize<T>(resultContent);

            if (result is null)
            {
                return Result.Fail($"Failed to deserialize response.");
            }

            return Result.Ok(result);
        }

        
        
        //Builds the URL to request data from the Weather API
        private string OpenWeatherUrlBuilder(string resource, UrlOptions options)
        {
            return $"https://api.openweathermap.org/data/2.5/{resource}?q=" +
                   $"{options.City}," +
                   $"{"za"}" +
                   $"&appid={_openWeatherConfig.ApiKey}" +
                   $"&units={options.Unit}";
        }
    }
}
