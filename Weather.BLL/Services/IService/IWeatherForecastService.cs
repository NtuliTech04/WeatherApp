using Weather.BLL.DTOs.CurrentForecastDtos;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.BLL.Queries.CurrentForecast;

namespace Weather.BLL.Services.IService
{
    public interface IWeatherForecastService
    {
        Task<CurrentForecastDto> GetCurrentForecast(string location, string unit, CancellationToken cancellationToken);
        Task<List<WeatherClientResponseDto>> GetFiveDayForecast(string location, string unit, CancellationToken cancellationToken);
    }
}