using OpenWeatherMap.Client.DTOs.WeatherResponse;

namespace OpenWeatherMap.Client.Abstractions
{
    public interface IOpenWeatherClient
    {
        List<WeatherResponseDataDto> GetFiveDayForecast(string location, string unit);
    }
}
