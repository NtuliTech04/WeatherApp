using Newtonsoft.Json;

namespace OpenWeatherMap.Client.Abstractions
{
    public interface IJsonSerializerSettingsFactory
    {
        JsonSerializerSettings Create();
    }
}
