using System.Text.Json.Serialization;

namespace Weather.BLL.DTOs
{
    public class WeatherResponseDto
    {
        public int Timestamp { get; set; }
        public int Visibility { get; set; }
        public MainDto Main { get; set; }
        public WindDto Wind { get; set; }
        public IReadOnlyCollection<WeatherDto> Weather { get; init; } = new List<WeatherDto>();
    }
}