using AutoMapper;
using Weather.BLL.DTOs.FiveDayWeatherDTOs;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
namespace Weather.BLL.Utilities.Mapping
{
    public static class FiveDaysWeatherMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                //Maps WeatherClientResponseDto Model from BLL to FiveDayWeatherDto from BLL
                CreateMap<WeatherClientResponseDto, FiveDayWeatherDto>()
                    .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp))
                    .ForMember(dest => dest.FiveDayTemps, opt => opt.MapFrom(src => src.Temperatures))
                    .ForMember(dest => dest.WeatherCondition, opt => opt.MapFrom(src => src.Weather));

                //Maps MainDto Model from BLL to FiveDayTempsDto from BLL
                CreateMap<MainDto, FiveDayTempsDto>()
                    .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => src.Temp))
                    .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Humidity));


                //Maps WeatherDto Model from BLL to FiveDayWeatherConditionDto from BLL
                CreateMap<WeatherDto, FiveDayWeatherConditionDto>()
                    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon));
            }
        }

    }
}
