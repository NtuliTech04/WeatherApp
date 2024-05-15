using System.ComponentModel.DataAnnotations.Schema;

namespace Weather.BLL.DTOs.FiveDayWeatherDTOs
{
    public class FiveDayWeatherDto
    {
        public long Timestamp { get; set; }
        public DateTime WeatherDate { get; set; }
        public decimal MinDayTemp { get; set; }
        public decimal MaxDayTemp { get; set; }
        public FiveDayTempsDto FiveDayTemps { get; set; }


        //public FiveDayWindDto FiveDayWind { get; set; }
        //public IReadOnlyCollection<FiveDayWeatherDto> FiveDayWeather { get; init; } = new List<FiveDayWeatherDto>();
    }


    public class FiveDayWeatherConditionDto
    {
        public string Condition { get; set; }
        public string Description { get; set; }
    }

    public class FiveDayTempsDto
    {
        public decimal Temp { get; set; }
        //public decimal FeelsLike { get; set; }
        //public decimal MinTemp { get; set; }
        //public decimal MaxTemp { get; set; }
        public int Humidity { get; set; }
    }

    public class FiveDayWindDto
    {
        public decimal Speed { get; set; }
        public int Direction { get; set; }
    }
}


