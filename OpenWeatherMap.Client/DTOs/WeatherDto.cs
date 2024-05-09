namespace OpenWeatherMap.Client.DTOs
{
    public sealed class WeatherDto
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}