using Weather.BLL.DTOs.FiveDayWeatherDTOs;

namespace Weather.BLL.Interfaces
{
    public interface ICustomWeatherRepository
    {
        Task<List<FiveDayWeatherDto>> GetFiveDayWeather(List<FiveDayWeatherDto> forecastList);
    }
}
