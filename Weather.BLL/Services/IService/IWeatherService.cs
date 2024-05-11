using Weather.BLL.DTOs;

namespace Weather.BLL.Services.IService
{
    public interface IWeatherService
    {
        List<WeatherClientResponseDto> GetWeatherForecast(string location, string unit);
    }
}