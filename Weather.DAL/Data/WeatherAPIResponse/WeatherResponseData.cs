using System.Text.Json.Serialization;

namespace Weather.DAL.Data.WeatherAPIResponse
{
    public sealed class WeatherResponseData
    {
        [JsonPropertyName("list")]
        public IReadOnlyCollection<WeatherResponse> WeatherForecastData { get; init; } = new List<WeatherResponse>();
    }
}