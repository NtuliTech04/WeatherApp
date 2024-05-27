using AutoMapper;
using Weather.BLL.DTOs.CurrentForecastDTOs;
using Weather.DAL.Data.CurrentWeatherResponse;
using Weather.DAL.Models.WeatherForecast;

namespace Weather.BLL.Utilities.Mapping
{
    public static class CurrentWeatherMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                //Maps Weather Data Model from DAL to CurentWeatherDto from BLL
                CreateMap<DAL.Models.WeatherForecast.Weather, CurrentWeatherDto>()
                    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.main))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                    .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.icon));


                //Maps Main Model from DAL to CurentTemperaturesDto from BLL
                CreateMap<Main, CurrentTempsDto>()
                    .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => src.temp))
                    .ForMember(dest => dest.FeelsLike, opt => opt.MapFrom(src => src.feels_like))
                    .ForMember(dest => dest.MinTemp, opt => opt.MapFrom(src => src.temp_min))
                    .ForMember(dest => dest.MaxTemp, opt => opt.MapFrom(src => src.temp_max))
                    .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.humidity));


                //Maps Wind Model from DAL to CurentWindDto from BLL
                CreateMap<Wind, CurrentWindDto>()
                    .ForMember(dest => dest.Speed, opt => opt.MapFrom(src => src.speed))
                    .ForMember(dest => dest.Direction, opt => opt.MapFrom(src => src.deg));


                //Maps WeatherResponse Model from DAL to CurrentForecastDto from BLL
                CreateMap<CurrentWeatherResponse, CurrentForecastDto>()
                    .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Dt))
                    .ForMember(dest => dest.Visibility, opt => opt.MapFrom(src => src.Visibility))
                    .ForMember(dest => dest.CurrentWeather, opt => opt.MapFrom(src => src.WeatherCondition))
                    .ForMember(dest => dest.CurrentTemps, opt => opt.MapFrom(src => src.Main))
                    .ForMember(dest => dest.CurrentWind, opt => opt.MapFrom(src => src.Wind))
                    .ForMember(dest => dest.CurrentCoord, opt => opt.MapFrom(src => src.Coord))
                    .ForMember(dest => dest.CurrentTimezone, opt => opt.MapFrom(src => src.Timezone))
                    .ForMember(dest => dest.CurrentLocality, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.CurrentGeoLocation, opt => opt.MapFrom(src => src.Sys));


                //Maps CurrentCoord Model from DAL to CurrentCoordDto from BLL
                CreateMap<CurrentCoord, CurrentCoordDto>()
                    .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.lat))
                    .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.lon));



                //Maps Sys Model from DAL to SysDto from BLL
                CreateMap<Sys, SysDto>()
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.country))
                    .ForMember(dest => dest.Sunrise, opt => opt.MapFrom(src => src.sunrise))
                    .ForMember(dest => dest.Sunset, opt => opt.MapFrom(src => src.sunset));
            }
        }
    }
}
