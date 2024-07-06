using Newtonsoft.Json;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.BLL.Utilities.Mappings.Generic;

namespace Weather.BLL.DTOs.FiveDayWeatherDTOs
{
    public class FiveDayWeatherDto : IMapFrom<WeatherClientResponseDto>
    {
        public long Timestamp { get; set; }
        public DateTime WeatherDate { get; set; }
        public decimal MinDayTemp { get; set; }
        public decimal MaxDayTemp { get; set; }
        public int Humidity => FiveDayTemps.Humidity;
        public FiveDayWeatherConditionDto WeatherCondition { get; set; }

        [JsonIgnore]
        public FiveDayTempsDto FiveDayTemps { get; set; }
    }
}