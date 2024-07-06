using AutoMapper;

namespace Weather.BLL.Utilities.Mappings.Generic
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
