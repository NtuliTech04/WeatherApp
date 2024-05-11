using System.Collections.Generic;

namespace Weather.BLL.DTOs
{
    public class WeatherClientResponseDataDto
    {
        public IReadOnlyCollection<WeatherClientResponseDto> WeatherForecastDataDto { get; init; } = new List<WeatherClientResponseDto>();
    }

    //public class WeatherClientGeoLocationResponseDataDto
    //{
    //    public WeatherClientResponseDto GeoLocationDataDto { get; init; } = new WeatherClientResponseDto();
    //}
}