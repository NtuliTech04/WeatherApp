namespace Weather.BLL.DTOs.WeatherClientResponseDTOs
{
    public class WeatherDto
    {
        public string Condition { get; set; }
        public string Description { get; set; }
    }

    public class MainDto
    {
        public decimal Temp { get; set; }
        public decimal FeelsLike { get; set; }
        public decimal MinTemp { get; set; }
        public decimal MaxTemp { get; set; }
        public int Humidity { get; set; }
    }

    public class WindDto
    {
        public decimal Speed { get; set; }
        public int Direction { get; set; }
    }


    //public class CityDto
    //{
    //    public string Name { get; set; }

    //    public CoordDto Coord { get; set; }
    //}

    //public class CoordDto
    //{
    //    public decimal Lat { get; set; }
    //    public decimal Lon { get; set; }
    //}
}
