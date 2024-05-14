using System.Text.Json.Serialization;

namespace Weather.BLL.DTOs.WeatherClientResponseDTOs
{
    public class WeatherClientResponseDto
    {
        public long Timestamp { get; set; }
        public int Visibility { get; set; }
        public MainDto Temperatures { get; set; }
        public WindDto Wind { get; set; }
        public IReadOnlyCollection<WeatherDto> WeatherCondition { get; init; } = new List<WeatherDto>();
    }

    //public class WeatherClientGeoLocationResponseDto
    //{
    //    public CityDto City { get; set; }
    //}
}