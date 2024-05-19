namespace Weather.BLL.DTOs.CurrentForecastDTOs
{
    public class CurrentForecastDto
    {
        public long Timestamp { get; set; }
        public DateTime LastUpdated => DateTimeOffset.FromUnixTimeSeconds(Timestamp).DateTime.ToLocalTime();
        public int Visibility { get; set; }
        public CurrentWeatherDto CurrentWeather { get; set; }
        public CurrentTempsDto CurrentTemps { get; set; }
        public CurrentWindDto CurrentWind { get; set; }
        public CurrentCoordDto CurrentCoord { get; set; }
        public string CurrentLocality { get; set; }
        public long CurrentTimezone { get; set; }
        public SysDto CurrentGeoArea { get; set; }
    }
}