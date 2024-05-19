namespace Weather.BLL.DTOs.WeatherClientResponseDTOs
{
    public class WeatherClientResponseDto
    {
        public long Timestamp { get; set; }
        public int Visibility { get; set; }
        public WeatherDto Weather { get; set; }
        public MainDto Temperatures { get; set; }
        public WindDto Wind { get; set; }
    } 
}