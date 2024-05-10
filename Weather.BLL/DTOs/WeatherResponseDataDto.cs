namespace Weather.BLL.DTOs
{
    public class WeatherResponseDataDto
    {
        public IReadOnlyCollection<WeatherResponseDto> WeatherForecastDataDto { get; init; } = new List<WeatherResponseDto>();
    }
}
