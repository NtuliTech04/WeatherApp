using AutoMapper;
using Weather.BLL.DTOs;
using Weather.BLL.DTOs.FiveDayWeatherDTOs;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.DAL.Data.WeatherClientResponse;
using Weather.DAL.Models.WeatherForecast;
namespace Weather.BLL.Utilities.Mapping
{
    public static class FiveDaysWeatherMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                //Maps Main Model from DAL to CurentTemperaturesDto from BLL
                CreateMap<WeatherClientResponseDto, FiveDayWeatherDto>()
                    .ForMember(dest => dest.FiveDayTemps, opt => opt.MapFrom(src => src.Temperatures));

                //Maps Main Model from DAL to CurentTemperaturesDto from BLL
                CreateMap<MainDto, FiveDayTempsDto>()
                    .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => src.Temp))
                    .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Humidity));

                //Maps WeatherResponse Model from DAL to CurrentForecastDto from BLL
                CreateMap<WeatherClientResponseDto, FiveDayWeatherDto>()
                    .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp))
                    .ForMember(dest => dest.FiveDayTemps, opt => opt.MapFrom(src => src.Temperatures));

            }
        }

    }
}
