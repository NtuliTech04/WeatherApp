using AutoMapper;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.DAL.Data.WeatherClientResponse;
using Weather.DAL.Models.Forecast;
using Weather.DAL.Models.Location;

namespace Weather.BLL.Utilities.Mappings.Manual
{
    public static class WeatherClientMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                //Maps Weather Model from DAL to WeatherDto from BLL
                CreateMap<DAL.Models.Forecast.Weather, WeatherDto>()
                    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.main))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                    .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.icon));



                //Maps Main Model from DAL to TemperaturesDto from BLL
                CreateMap<Main, MainDto>()
                    .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => src.temp))
                    .ForMember(dest => dest.FeelsLike, opt => opt.MapFrom(src => src.feels_like))
                    .ForMember(dest => dest.MinTemp, opt => opt.MapFrom(src => src.temp_min))
                    .ForMember(dest => dest.MaxTemp, opt => opt.MapFrom(src => src.temp_max))
                    .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.humidity));



                //Maps Wind Model from DAL to WindDto from BLL
                CreateMap<Wind, WindDto>()
                    .ForMember(dest => dest.Speed, opt => opt.MapFrom(src => src.speed))
                    .ForMember(dest => dest.Direction, opt => opt.MapFrom(src => src.deg));



                //Maps WeatherResponse Model from DAL to WeatherResponseDto from BLL
                CreateMap<WeatherClientResponse, WeatherClientResponseDto>()
                    .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Dt))
                    .ForMember(dest => dest.Visibility, opt => opt.MapFrom(src => src.Visibility))
                    .ForMember(dest => dest.Weather, opt => opt.MapFrom(src => src.WeatherCondition))
                    .ForMember(dest => dest.Temperatures, opt => opt.MapFrom(src => src.Main))
                    .ForMember(dest => dest.Wind, opt => opt.MapFrom(src => src.Wind));


                //Maps City Model from DAL to CityDto from BLL
                CreateMap<City, CityDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.Coord, opt => opt.MapFrom(src => src.coord))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.country))
                    .ForMember(dest => dest.Timezone, opt => opt.MapFrom(src => src.timezone))
                    .ForMember(dest => dest.Sunrise, opt => opt.MapFrom(src => src.sunrise))
                    .ForMember(dest => dest.Sunset, opt => opt.MapFrom(src => src.sunset));



                //Maps Coordinates Model from DAL to Coordinates Dto from BLL
                CreateMap<Coord, CoordDto>()
                    .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.lat))
                    .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.lon));


                //Maps WeatherAPIResponse Data Model from DAL to WeatherAPIResponse DTO from BLL
                CreateMap<WeatherClientResponseData, WeatherClientResponseDataDto>()
                    .ForMember(dest => dest.WeatherForecastDataDto, opt => opt.MapFrom(src => src.WeatherForecastData))
                    .ForMember(dest => dest.LocationDataDto, opt => opt.MapFrom(src => src.LocationData));
            }
        }
    }
}
