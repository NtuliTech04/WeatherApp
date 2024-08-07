﻿using Weather.BLL.Utilities.Mappings.Generic;
using Weather.DAL.Data.CurrentWeatherResponse;
using Weather.DAL.Models.Forecast;

namespace Weather.BLL.DTOs.CurrentForecastDTOs
{
    public class CurrentWeatherDto : IGenericMapper<DAL.Models.Forecast.Weather>
    {
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class CurrentTempsDto : IGenericMapper<Main>
    {
        public decimal Temp { get; set; }
        public decimal FeelsLike { get; set; }
        public decimal MinTemp { get; set; }
        public decimal MaxTemp { get; set; }
        public int Humidity { get; set; }
    }

    public class CurrentWindDto : IGenericMapper<Wind> 
    {
        public decimal Speed { get; set; }
        public int Direction { get; set; }
    }

    public class CurrentCoordDto : IGenericMapper<CurrentCoord>
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class SysDto : IGenericMapper<Sys> 
    {
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}
