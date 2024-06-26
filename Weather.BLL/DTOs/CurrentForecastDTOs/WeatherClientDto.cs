﻿namespace Weather.BLL.DTOs.CurrentForecastDTOs
{
    public class CurrentWeatherDto
    {
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
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

    public class CurrentCoordDto
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class SysDto
    {
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}
