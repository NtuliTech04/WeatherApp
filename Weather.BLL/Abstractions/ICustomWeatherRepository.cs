using Weather.BLL.DTOs.FiveDayWeatherDTOs;

namespace Weather.BLL.Abstractions
{
    public interface ICustomWeatherRepository
    {
        Task<List<FiveDayWeatherDto>> GetFiveDayWeather(List<FiveDayWeatherDto> forecastList);
    }
}
