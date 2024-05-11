using Weather.BLL.DTOs;

namespace Weather.BLL.Services.IService
{
    public interface IWeatherService
    {
        List<WeatherResponseDto> GetWeatherForecast(string location, string unit);
    }
}