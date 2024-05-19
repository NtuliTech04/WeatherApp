using System.Text.Json.Serialization;
using Weather.DAL.Models.GeoArea;

namespace Weather.DAL.Data.WeatherClientResponse
{
    public class WeatherClientResponseData
    {
        [JsonPropertyName("list")]
        public IReadOnlyCollection<WeatherClientResponse> WeatherForecastData { get; init; } = new List<WeatherClientResponse>();

        [JsonPropertyName("city")]
        public City LocationData { get; set; }
    }
}