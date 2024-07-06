using System.Text.Json.Serialization;
using Weather.DAL.Models.Location;

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