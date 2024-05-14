using System.Text.Json.Serialization;

namespace Weather.DAL.Data.WeatherClientResponse
{
    public class WeatherClientResponseData
    {
        [JsonPropertyName("list")]
        public IReadOnlyCollection<WeatherClientResponse> WeatherForecastData { get; init; } = new List<WeatherClientResponse>();
    }
    
    //public class WeatherClientGeoLocationResponseData
    //{
    //    [JsonPropertyName("city")]
    //    public WeatherClientResponse GeoLocationData { get; init; } = new WeatherClientResponse();
    //}
}