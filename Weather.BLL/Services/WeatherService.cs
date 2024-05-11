using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Weather.BLL.Constants.Resources;
using Weather.BLL.DTOs;
using Weather.BLL.Services.IService;
using Weather.BLL.Utilities.Exceptions;
using Weather.DAL.Abstractions;

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


        public List<WeatherClientResponseDto> GetWeatherForecast(string location, string unit)
        {
            var forecastResult = _openWeatherClient.GetFiveDayForecast(location, unit);

            if (forecastResult.IsFailed)
            {
                throw new BadRequestException(Result.Fail(forecastResult.Errors).ToString());
            }

            if (forecastResult.Value is null || !forecastResult.Value.WeatherForecastData.Any())
            {
                throw new Utilities.Exceptions.NotFoundException(ErrorMessages.GetDataFailed_NullOrEmpty);
            }

            var mappedForecast = _mapper.Map<WeatherClientResponseDataDto>(forecastResult.Value);

            return mappedForecast.WeatherForecastDataDto.ToList();
        }
    }
}
