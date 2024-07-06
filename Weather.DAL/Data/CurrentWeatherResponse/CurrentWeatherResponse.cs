using System.Text.Json.Serialization;
using Weather.DAL.Models.Forecast;

namespace Weather.DAL.Data.CurrentWeatherResponse
{
    public class CurrentWeatherResponse
    {
        [JsonPropertyName("dt")]
        public long Dt { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("weather")]
        public List<Models.Forecast.Weather> Weather { get; init; } = new List<Models.Forecast.Weather>();

        public Models.Forecast.Weather WeatherCondition => Weather.First();

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("coord")]
        public CurrentCoord Coord { get; set; }

        [JsonPropertyName("sys")]
        public Sys Sys { get; set; }

        [JsonPropertyName("timezone")]
        public long Timezone { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }


    public class CurrentCoord
    {
        public decimal lon { get; set; }
        public decimal lat { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public long id { get; set; }
        public string country { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
    }
}
