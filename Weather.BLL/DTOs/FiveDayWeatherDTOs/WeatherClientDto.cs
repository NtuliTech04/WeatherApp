﻿namespace Weather.BLL.DTOs.FiveDayWeatherDTOs
{
    public class FiveDayWeatherConditionDto
    {
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class FiveDayTempsDto
    {
        public decimal Temp { get; set; }
        public int Humidity { get; set; }
    }

    public class FiveDayWindDto
    {
        public decimal Speed { get; set; }
        public int Direction { get; set; }
    }
}
