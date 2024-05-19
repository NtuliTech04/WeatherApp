namespace Weather.BLL.DTOs.WeatherClientResponseDTOs
{
    public class WeatherDto
    {
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class MainDto
    {
        public decimal Temp { get; set; }
        public int FeelsLike { get; set; }
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
        public int Humidity { get; set; }
    }

    public class WindDto
    {
        public int Speed { get; set; }
        public int Direction { get; set; }
    }

    public class CityDto
    {
        public string Name { get; set; }
        public CoordDto Coord { get; set; }
        public string Country { get; set; }
        public long Timezone { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }

    public class CoordDto
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}