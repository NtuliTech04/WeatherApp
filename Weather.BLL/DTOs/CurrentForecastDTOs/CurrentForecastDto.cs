using Weather.BLL.Utilities.Mappings.Generic;
using Weather.DAL.Data.CurrentWeatherResponse;

namespace Weather.BLL.DTOs.CurrentForecastDTOs
{
    public class CurrentForecastDto : IMapFrom<CurrentWeatherResponse>
    {   
        public long Timestamp { get; set; }
        public DateTime LastUpdated => GetHumanDate(Timestamp);
        public int Visibility { get; set; }
        public CurrentWeatherDto CurrentWeather { get; set; }
        public CurrentTempsDto CurrentTemps { get; set; }
        public CurrentWindDto CurrentWind { get; set; }
        public CurrentCoordDto CurrentCoord { get; set; }
        public string CurrentLocality { get; set; }
        public long CurrentTimezone { get; set; }
        public SysDto CurrentGeoLocation { get; set; }


        private DateTime GetHumanDate(long timestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime.ToLocalTime();
        }
    }
}