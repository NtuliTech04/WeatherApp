using AutoMapper;
using Weather.BLL.DTOs;
using Weather.DAL.Models;

namespace Weather.BLL.Utilities.Mappings.Manual
{
    public static class UrlOptionsMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                //Maps UrlOptionsDto (src) Model from BLL to UrlOptions (dest) from DAL
                CreateMap<UrlOptionsDto, UrlOptions>() //.ReverseMap() -> In this case I changed src & dest manually
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                    .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit));
            }
        }
    }
}
