using System.Text.Json.Serialization;

namespace Weather.DAL.Models.Location
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }

        [JsonPropertyName("coord")]
        public Coord coord { get; set; }

        public string country { get; set; }
        public long timezone { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
    }

    public class Coord
    {
        public decimal lat { get; set; }
        public decimal lon { get; set; }
    }
}
