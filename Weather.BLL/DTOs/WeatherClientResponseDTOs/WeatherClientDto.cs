using Weather.BLL.Utilities.Mappings.Generic;
using Weather.DAL.Models.Forecast;
using Weather.DAL.Models.Location;

namespace Weather.BLL.DTOs.WeatherClientResponseDTOs
{
    public class WeatherDto : IMapFrom<DAL.Models.Forecast.Weather>
    {
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class MainDto : IMapFrom<Main>
    {
        public decimal Temp { get; set; }
        public decimal FeelsLike { get; set; }
        public decimal MinTemp { get; set; }
        public decimal MaxTemp { get; set; }
        public int Humidity { get; set; }
    }

    public class WindDto : IMapFrom<Wind> 
    {
        public decimal Speed { get; set; }
        public int Direction { get; set; }
    }

    public class CityDto : IMapFrom<City>
    {
        public string Name { get; set; }
        public CoordDto Coord { get; set; }
        public string Country { get; set; }
        public long Timezone { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }

    public class CoordDto : IMapFrom<Coord>
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}