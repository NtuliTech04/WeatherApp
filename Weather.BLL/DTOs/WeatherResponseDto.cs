namespace Weather.BLL.DTOs
{
    public class WeatherResponseDto
    {
        public int Code { get; set; }
        public int Timestamp { get; set; }
        public int Visibility { get; set; }
        public TemperaturesDto Temperatures { get; set; }
        public WeatherConditionDto Weather { get; set; }
        public WindDto Wind { get; set; }
    }

}