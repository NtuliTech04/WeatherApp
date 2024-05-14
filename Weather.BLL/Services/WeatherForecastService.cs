﻿using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Weather.BLL.Constants.Resources;
using Weather.BLL.DTOs.CurrentForecastDtos;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.BLL.Queries.CurrentForecast;
using Weather.BLL.Services.IService;
using Weather.BLL.Utilities.Exceptions;
using Weather.DAL.Abstractions;

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

        public async Task<CurrentForecastDto> GetCurrentForecast(string location, string unit, CancellationToken cancellationToken)
        {
            var currentResult = await _openWeatherClient.CurrentForecastResponse(location, unit, cancellationToken);
            if (currentResult.IsFailed)
            {
                throw new BadRequestException(Result.Fail(currentResult.Errors).ToString());
            }

            if (currentResult.Value is null)
            {
                throw new Utilities.Exceptions.NotFoundException(ErrorMessages.GetDataFailed_NullOrEmpty);
            }

            //if (currentResult.Value.CurrentForecastData.Count != 1)
            //{
            //    throw new Utilities.Exceptions.ApplicationException(string.Format(ErrorMessages.GetDataFailed_InvalidCount, currentResult.Value.CurrentForecastData.Count));
            //}

            var mappedForecast = _mapper.Map<CurrentForecastDto>(currentResult.Value);

            return mappedForecast;
        }

        public async Task<List<WeatherClientResponseDto>> GetFiveDayForecast(string location, string unit, CancellationToken cancellationToken)
        {
            var fiveDayResult = await _openWeatherClient.FiveDayForecastResponse(location, unit, cancellationToken);

            if (fiveDayResult.IsFailed)
            {
                throw new BadRequestException(Result.Fail(fiveDayResult.Errors).ToString());
            }

            if (fiveDayResult.Value is null || !fiveDayResult.Value.WeatherForecastData.Any())
            {
                throw new Utilities.Exceptions.NotFoundException(ErrorMessages.GetDataFailed_NullOrEmpty);
            }

            var mappedForecast = _mapper.Map<WeatherClientResponseDataDto>(fiveDayResult.Value);

            return mappedForecast.WeatherForecastDataDto.ToList();
        }
    }
}