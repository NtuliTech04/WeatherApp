using System.Text.Json.Serialization;

namespace OpenWeatherMap.Client.DTOs.WeatherResponse
{
    public class WeatherResponseDto
    {
        public int cod { get; set; }
        public int dt { get; set; }
        public int visibility { get; set; }

        [JsonPropertyName("weather")]
        public WeatherDto WeatherDto { get; set; }

        [JsonPropertyName("main")]
        public MainDto MainDto { get; set; }

        [JsonPropertyName("wind")]
        public WindDto WindDto { get; set; }

        [JsonPropertyName("clouds")]
        public CloudsDto CloudsDto { get; set; }
    }
}
