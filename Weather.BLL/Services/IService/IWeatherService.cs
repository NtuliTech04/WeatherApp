using FluentResults;
using Weather.BLL.DTOs;

namespace Weather.BLL.Services.IService
{
    public interface IWeatherService
    {
        Task<Result<WeatherResponseDataDto>> GetForecastWeather(string location, string unit);
    }
}
