﻿using AutoMapper;
using Weather.DAL.Data.WeatherAPIResponse;

namespace Weather.BLL.Utilities.Mapping
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                //Maps WeatherResponse Model from DAL to WeatherResponseDto from BLL
                CreateMap<WeatherResponse, Weather.BLL.DTOs.WeatherResponseDto>()
                    .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.cod))
                    .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.dt))
                    .ForMember(dest => dest.Visibility, opt => opt.MapFrom(src => src.visibility));

                //Maps Wind Model from DAL to WindDto from BLL
                CreateMap<Weather.DAL.Models.Wind, Weather.BLL.DTOs.WindDto>()
                    .ForMember(dest => dest.Speed, opt => opt.MapFrom(src => src.speed))
                    .ForMember(dest => dest.Direction, opt => opt.MapFrom(src => src.deg));

                //Maps WeatherCondition Model from DAL to WeatherConditionDto from BLL
                CreateMap<Weather.DAL.Models.WeatherCondition, Weather.BLL.DTOs.WeatherConditionDto>()
                    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.description));

                //Maps Main Model from DAL to TemperaturesDto from BLL
                CreateMap<Weather.DAL.Models.Main, Weather.BLL.DTOs.TemperaturesDto>()
                    .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => src.temp))
                    .ForMember(dest => dest.FeelsLike, opt => opt.MapFrom(src => src.feels_like))
                    .ForMember(dest => dest.MinTemp, opt => opt.MapFrom(src => src.temp_min))
                    .ForMember(dest => dest.MaxTemp, opt => opt.MapFrom(src => src.temp_max))
                    .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.humidity));

                //CreateMap<User, UserDTO>().ReverseMap(); //For same property names
            }
        }
    }
}