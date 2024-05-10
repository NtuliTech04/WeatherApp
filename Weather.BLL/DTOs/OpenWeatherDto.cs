namespace Weather.BLL.DTOs
{

    public class OpenWeatherDto
    {

    }

    public class TemperaturesDto
    {
        public decimal Temp { get; set; }
        public decimal FeelsLike { get; set; }
        public decimal MinTemp { get; set; }
        public decimal MaxTemp { get; set; }
        public byte Humidity { get; set; }

    }

    public class WeatherConditionDto
    {
        public string Condition { get; set; }
    }

    public class WindDto
    {
        public decimal Speed { get; set; }
        public int Direction { get; set; }
    }
}
