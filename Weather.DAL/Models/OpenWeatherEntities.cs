using System.Text.Json.Serialization;

namespace Weather.DAL.Models
{
    public class Forcast
    {
        [JsonPropertyName("dt")]
        public int Timestamp { get; set; }

        [JsonPropertyName("main")]
        public Temperatures Temperatures { get; set; }

        [JsonPropertyName("weather")]
        public Weather Weather { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
    }

    public class Temperatures
    {
        [JsonPropertyName("temp")]
        public decimal Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public decimal FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public decimal MinTemp { get; set; }

        [JsonPropertyName("temp_max")]
        public decimal MaxTemp { get; set; }

        [JsonPropertyName("humidity")]
        public byte Humidity { get; set; }

    }

    public class Weather
    {
        [JsonPropertyName("description")]
        public string Condition { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public decimal Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Direction { get; set; }
    }
}
