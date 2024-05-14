using Weather.BLL.DTOs.CurrentForecastDtos;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;

namespace Weather.BLL.Interfaces
{
    public interface IWeatherForecastRepository
    {
        Task<CurrentForecastDto> GetCurrentForecast(List<WeatherClientResponseDto> forecastData);
    }
}
