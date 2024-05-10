using Newtonsoft.Json;

namespace Weather.DAL.Abstractions
{
    public interface IJsonSerializerSettingsFactory
    {
        JsonSerializerSettings Create();
    }
}
