namespace OpenWeatherMap.Client.DTOs.WeatherResponse
{
    public sealed class WeatherResponseDataDto
    {
        public IReadOnlyCollection<WeatherResponseDto> WeatherResponseData { get; init; } = new List<WeatherResponseDto>();
    }
}