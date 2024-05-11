using AutoMapper;

namespace Weather.BLL.Utilities.Mapping
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                //Maps WeatherResponse Model from DAL to WeatherResponseDto from BLL
                CreateMap<Weather.DAL.Data.WeatherAPIResponse.WeatherResponse, Weather.BLL.DTOs.WeatherResponseDto>()
                    .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.dt))
                    .ForMember(dest => dest.Visibility, opt => opt.MapFrom(src => src.visibility))
                    .ForMember(dest => dest.Weather, opt => opt.MapFrom(src => src.Weather));

                //Maps Weather Data Model from DAL to WeatherDto from BLL
                CreateMap<Weather.DAL.Models.Weather, Weather.BLL.DTOs.WeatherDto>()
                    .ForMember(dest => dest.Main, opt => opt.MapFrom(src => src.main))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description));

                //Maps Main Model from DAL to TemperaturesDto from BLL
                CreateMap<Weather.DAL.Models.Main, Weather.BLL.DTOs.MainDto>()
                    .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => src.temp))
                    .ForMember(dest => dest.FeelsLike, opt => opt.MapFrom(src => src.feels_like))
                    .ForMember(dest => dest.MinTemp, opt => opt.MapFrom(src => src.temp_min))
                    .ForMember(dest => dest.MaxTemp, opt => opt.MapFrom(src => src.temp_max))
                    .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.humidity));

                //Maps Wind Model from DAL to WindDto from BLL
                CreateMap<Weather.DAL.Models.Wind, Weather.BLL.DTOs.WindDto>()
                    .ForMember(dest => dest.Speed, opt => opt.MapFrom(src => src.speed))
                    .ForMember(dest => dest.Direction, opt => opt.MapFrom(src => src.deg));


                //Maps WeatherAPIResponse Data Model from DAL to WeatherAPIResponse DTO from BLL
                CreateMap<Weather.DAL.Data.WeatherAPIResponse.WeatherResponseData, Weather.BLL.DTOs.WeatherResponseDataDto>()
                    .ForMember(dest => dest.WeatherForecastDataDto, opt => opt.MapFrom(src => src.WeatherForecastData));
            }
        }
    }
}
