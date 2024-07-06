using Weather.BLL.DTOs;
using Weather.BLL.DTOs.CurrentForecastDTOs;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;

namespace Weather.BLL.Services.IService
{
    public interface IWeatherForecastService
    {
        Task<CurrentForecastDto> GetCurrentForecast(UrlOptionsDto options, CancellationToken cancellationToken);
        Task<WeatherClientResponseDataDto> GetFiveDayForecast(UrlOptionsDto options, CancellationToken cancellationToken);
    }
}