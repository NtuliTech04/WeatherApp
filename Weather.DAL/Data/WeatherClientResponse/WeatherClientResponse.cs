using System.Text.Json.Serialization;
using Weather.DAL.Models.Forecast;

namespace Weather.DAL.Data.WeatherClientResponse
{
    public class WeatherClientResponse
    {
        [JsonPropertyName("dt")]
        public long Dt { get; set; }

        [JsonPropertyName("weather")]
        public List<Models.Forecast.Weather> Weather { get; init; } = new List<Models.Forecast.Weather>();

        public Models.Forecast.Weather WeatherCondition => Weather.First();
        
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