using AutoMapper;

namespace Weather.BLL.Utilities.Mappings.Generic
{
    public interface IGenericMapper<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
    }
}