using Newtonsoft.Json;
using Weather.BLL.Utilities.Mappings.Generic;
using Weather.DAL.Data.WeatherClientResponse;

namespace Weather.BLL.DTOs.WeatherClientResponseDTOs
{
    public class WeatherClientResponseDto : IGenericMapper<WeatherClientResponse>
    {
        public long Timestamp { get; set; }
        public int Visibility { get; set; }
        public WeatherDto Weather { get; set; }
        public MainDto Temperatures { get; set; }
        public WindDto Wind { get; set; }
    } 
}