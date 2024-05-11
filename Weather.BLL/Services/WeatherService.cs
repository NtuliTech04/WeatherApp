using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Weather.BLL.DTOs;
using Weather.BLL.Services.IService;
using Weather.DAL.Abstractions;
using Weather.BLL.Constants.Resources;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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


        public List<WeatherResponseDto> GetWeatherForecast(string location, string unit)
        {
            var forecastResult = _openWeatherClient.GetFiveDayForecast(location, unit);

            if (forecastResult.IsFailed)
            {
                //return await Task.Run(() => Result.Fail(forecastResult.Errors));
            }

            if (forecastResult.Value is null || !forecastResult.Value.WeatherForecastData.Any())
            {
                //return await Task.Run(() => Result.Fail(ErrorMessages.GetDataFailed_InvalidCount));
            }

            var mappedForecast = _mapper.Map<WeatherResponseDataDto>(forecastResult.Value);

            return mappedForecast.WeatherForecastDataDto.ToList();
        }
    }
}
