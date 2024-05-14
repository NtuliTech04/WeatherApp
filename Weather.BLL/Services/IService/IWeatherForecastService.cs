using Weather.BLL.DTOs;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;

namespace Weather.BLL.Services.IService
{
    public interface IWeatherForecastService
    {
        Task<CurrentForecastDto> GetCurrentForecast(string location, string unit, CancellationToken cancellationToken);
        Task<List<WeatherClientResponseDto>> GetFiveDayForecast(string location, string unit, CancellationToken cancellationToken);
    }
}