using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Weather.BLL.DTOs;
using Weather.BLL.Services.IService;
using Weather.DAL.Abstractions;
using Weather.BLL.Resources;

namespace Weather.BLL.Services
{
    internal sealed class WeatherService : IWeatherService
    {
        private readonly IOpenWeatherClient _openWeatherClient;
        private readonly IMapper _mapper;

        public WeatherService(IOpenWeatherClient openWeatherClient, IMapper mapper)
        {
            _openWeatherClient = Guard.Against.Null(openWeatherClient);
            _mapper = Guard.Against.Null(mapper);
        }


        public async Task<Result<WeatherResponseDataDto>> GetForecastWeather(string location, string unit)
        {
            var forecastResult = await _openWeatherClient.GetFiveDayForecast(location, unit);

            if (forecastResult.IsFailed)
            {
                return Result.Fail(forecastResult.Errors);
            }

            if (forecastResult.Value is null || forecastResult.Value.WeatherForecastData.Any())
            {
                return Result.Fail(ErrorMessages.GetDataFailed_InvalidCount);
            }

            return _mapper.Map<WeatherResponseDataDto>(forecastResult.Value);
        }
    }
}
