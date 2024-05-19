using System.Text.Json.Serialization;
using Weather.DAL.Models.WeatherForecast;

namespace Weather.DAL.Data.WeatherClientResponse
{
    public class WeatherClientResponse
    {
        [JsonPropertyName("dt")]
        public long Dt { get; set; }

        [JsonPropertyName("weather")]
        public List<Models.WeatherForecast.Weather> Weather { get; init; } = new List<Models.WeatherForecast.Weather>();

        public Models.WeatherForecast.Weather WeatherCondition => Weather.First();
        
        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }
    }
}