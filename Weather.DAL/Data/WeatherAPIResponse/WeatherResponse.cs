using System.Text.Json.Serialization;
using Weather.DAL.Models;

namespace Weather.DAL.Data.WeatherAPIResponse
{
    public class WeatherResponse
    {
        [JsonPropertyName("dt")]
        public int dt { get; set; }

        [JsonPropertyName("weather")]
        public IReadOnlyCollection<Weather.DAL.Models.Weather> 
            Weather { get; init; } = new List<Weather.DAL.Models.Weather>();

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("visibility")]
        public int visibility { get; set; }
    }
}