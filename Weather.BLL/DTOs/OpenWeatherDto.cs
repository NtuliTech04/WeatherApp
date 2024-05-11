namespace Weather.BLL.DTOs
{
    public class WeatherDto
    {
        public string Main { get; set; }
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
}
