using Weather.BLL.DTOs;
using Weather.BLL.DTOs.FiveDayWeatherDTOs;

namespace Weather.BLL.Services.IService
{
    public interface ICustomWeatherService
    {
        Task<List<FiveDayWeatherDto>> FiveDayWeather(UrlOptionsDto options, CancellationToken cancellationToken);
    }
}
