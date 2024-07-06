using Weather.BLL.Utilities.Mappings.Generic;
using Weather.DAL.Data.WeatherClientResponse;

namespace Weather.BLL.DTOs.WeatherClientResponseDTOs
{
    public class WeatherClientResponseDataDto : IGenericMapper<WeatherClientResponseData>
    {
        public IReadOnlyCollection<WeatherClientResponseDto> WeatherForecastDataDto { get; init; } = new List<WeatherClientResponseDto>();

        public CityDto LocationDataDto { get; set; } = new CityDto();
    }
}