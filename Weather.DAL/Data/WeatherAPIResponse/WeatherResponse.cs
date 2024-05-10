using System.Text.Json.Serialization;
using Weather.DAL.Models;

namespace Weather.DAL.Data.WeatherAPIResponse
{
    public class WeatherResponse
    {
        [JsonPropertyName("cod")]
        public int cod { get; set; }

        [JsonPropertyName("dt")]
        public int dt { get; set; }

        [JsonPropertyName("visibility")]
        public int visibility { get; set; }

        [JsonPropertyName("weather")]
        public WeatherCondition Weather { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }
    }
}
