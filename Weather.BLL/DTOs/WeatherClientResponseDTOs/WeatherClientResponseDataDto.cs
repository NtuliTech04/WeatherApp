namespace Weather.BLL.DTOs.WeatherClientResponseDTOs
{
    public class WeatherClientResponseDataDto
    {
        public IReadOnlyCollection<WeatherClientResponseDto> WeatherForecastDataDto { get; init; } = new List<WeatherClientResponseDto>();

        public CityDto LocationDataDto { get; set; }
    }
}