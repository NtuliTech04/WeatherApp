using Weather.BLL.DTOs.CurrentForecastDTOs;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;

namespace Weather.BLL.Services.IService
{
    public interface IWeatherForecastService
    {
        Task<CurrentForecastDto> GetCurrentForecast(string location, string unit, CancellationToken cancellationToken);
        Task<WeatherClientResponseDataDto> GetFiveDayForecast(string location, string unit, CancellationToken cancellationToken);
    }
}