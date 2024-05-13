using System.Text.Json.Serialization;

namespace Weather.DAL.Models.GeoArea
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
    }

    public class Coord
    {
        public decimal lat { get; set; }
        public decimal lon { get; set; }
    }
}
