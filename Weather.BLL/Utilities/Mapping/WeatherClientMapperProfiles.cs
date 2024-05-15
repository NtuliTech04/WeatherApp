﻿using AutoMapper;
using Weather.BLL.DTOs.WeatherClientResponseDTOs;
using Weather.DAL.Data.WeatherClientResponse;
using Weather.DAL.Models.WeatherForecast;

namespace Weather.BLL.Utilities.Mapping
{
    public static class WeatherClientMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                //Maps Weather Data Model from DAL to WeatherDto from BLL
                CreateMap<DAL.Models.WeatherForecast.Weather, WeatherDto>()
                    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.main))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description));

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

                ////Maps WeatherAPIResponse Data Model from DAL to WeatherAPIResponse DTO from BLL
                CreateMap<WeatherClientResponseData, WeatherClientResponseDataDto>()
                    .ForMember(dest => dest.WeatherForecastDataDto, opt => opt.MapFrom(src => src.WeatherForecastData));

                //Maps WeatherResponse Model from DAL to WeatherResponseDto from BLL
                CreateMap<WeatherClientResponse, WeatherClientResponseDto>()
                    .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.dt))
                    .ForMember(dest => dest.Visibility, opt => opt.MapFrom(src => src.visibility))
                    .ForMember(dest => dest.WeatherCondition, opt => opt.MapFrom(src => src.Weather))
                    .ForMember(dest => dest.Temperatures, opt => opt.MapFrom(src => src.Main))
                    .ForMember(dest => dest.Wind, opt => opt.MapFrom(src => src.Wind));


                ////Maps City Model from DAL to CityDto from BLL
                //CreateMap<Weather.DAL.Models.City, Weather.BLL.DTOs.CityDto>()
                //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name));

                ////Maps Coord Model from DAL to CoordDto from BLL
                //CreateMap<Weather.DAL.Models.Coord, Weather.BLL.DTOs.CoordDto>()
                //    .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.lat))
                //    .ForMember(dest => dest.Lon, opt => opt.MapFrom(src => src.lon));
            }
        }
    }
}