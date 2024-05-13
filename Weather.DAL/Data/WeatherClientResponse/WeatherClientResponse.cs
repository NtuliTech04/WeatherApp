using System.Text.Json.Serialization;
using Weather.DAL.Models.WeatherForecast;

namespace Weather.DAL.Data.WeatherClientResponse
{
    public class WeatherClientResponse
    {
        [JsonPropertyName("dt")]
        public int dt { get; set; }

        [JsonPropertyName("weather")]
        public IReadOnlyCollection<Models.WeatherForecast.Weather> Weather { get; init; } = new List<Models.WeatherForecast.Weather>();

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("visibility")]
        public int visibility { get; set; }
    }

    //public class WeatherClientGeoLocationResponse
    //{
    //    [JsonPropertyName("city")]
    //    public City City { get; set; }
    //}
}