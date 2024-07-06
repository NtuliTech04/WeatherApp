using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Weather.BLL.Constants.Resources;
using Weather.BLL.DTOs;
using Weather.BLL.DTOs.CurrentForecastDTOs;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.BLL.Services.IService;
using Weather.BLL.Utilities.Exceptions;
using Weather.DAL.Abstractions;
using Weather.DAL.Models;

namespace Weather.BLL.Services
{
    internal sealed class WeatherForecastService : IWeatherForecastService
    {
        #region Weather Forecast Service Constructors

        private readonly IOpenWeatherClient _openWeatherClient;
        private readonly IMapper _mapper;

        public WeatherForecastService(IOpenWeatherClient openWeatherClient, IMapper mapper)
        {
            _openWeatherClient = Guard.Against.Null(openWeatherClient);
            _mapper = Guard.Against.Null(mapper);
        }

        #endregion

        public async Task<CurrentForecastDto> GetCurrentForecast(UrlOptionsDto options, CancellationToken cancellationToken)
        {
            var currentResult = await _openWeatherClient.CurrentForecastResponse(_mapper.Map<UrlOptions>(options), cancellationToken);
            if (currentResult.IsFailed) 
            {
                throw new BadRequestException(Result.Fail(currentResult.Errors).ToString());
            }

            if (currentResult.Value is null)
            {
                throw new Utilities.Exceptions.NotFoundException(ErrorMessages.GetDataFailed_NullOrEmpty);
            }

            return _mapper.Map<CurrentForecastDto>(currentResult.Value);
        }

        public async Task<WeatherClientResponseDataDto> GetFiveDayForecast(UrlOptionsDto options, CancellationToken cancellationToken)
        {
            var fiveDayResult = await _openWeatherClient.FiveDayForecastResponse(_mapper.Map<UrlOptions>(options), cancellationToken);

            if (fiveDayResult.IsFailed)
            {
                throw new BadRequestException(Result.Fail(fiveDayResult.Errors).ToString());
            }

            if (fiveDayResult.Value is null || !fiveDayResult.Value.WeatherForecastData.Any())
            {
                throw new Utilities.Exceptions.NotFoundException(ErrorMessages.GetDataFailed_NullOrEmpty);
            }

            var mappedForecast = _mapper.Map<WeatherClientResponseDataDto>(fiveDayResult.Value);

            return mappedForecast;
        }
    }
}