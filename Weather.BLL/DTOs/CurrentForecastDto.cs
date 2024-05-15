﻿namespace Weather.BLL.DTOs
{
    public class CurrentForecastDto
    {
        public long Timestamp { get; set; }
        public DateTime UpdatedOn => DateTimeOffset.FromUnixTimeSeconds(Timestamp).DateTime.ToLocalTime();
        public int Visibility { get; set; }
        public CurrentTempsDto CurrentTemps { get; set; }
        public CurrentWindDto CurrentWind { get; set; }
        public IReadOnlyCollection<CurrentWeatherDto> CurrentWeather { get; init; } = new List<CurrentWeatherDto>();
    }

    public class CurrentWeatherDto
    {
        public string Condition { get; set; }
        public string Description { get; set; }
    }

    public class CurrentTempsDto
    {
        public decimal Temp { get; set; }
        public decimal FeelsLike { get; set; }
        public decimal MinTemp { get; set; }
        public decimal MaxTemp { get; set; }
        public int Humidity { get; set; }
    }

    public class CurrentWindDto
    {
        public decimal Speed { get; set; }
        public int Direction { get; set; }
    }
}
