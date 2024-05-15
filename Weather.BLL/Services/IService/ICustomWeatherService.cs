using Weather.BLL.DTOs.FiveDayWeatherDTOs;

namespace Weather.BLL.Services.IService
{
    public interface ICustomWeatherService
    {
        Task<List<FiveDayWeatherDto>> GetFiveDayWeather(string location, string unit, CancellationToken cancellationToken);
        //Task<List<DayHourlyForecast>> GetHourlyForecast(DateTime day, string location, string unit, CancellationToken cancellationToken);
    }
}
