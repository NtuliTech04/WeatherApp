using Newtonsoft.Json;
using OpenWeatherMap.Client.Abstractions;

namespace OpenWeatherMap.Client.Factories
{
    internal sealed class JsonSerializerSettingsFactory : IJsonSerializerSettingsFactory
    {
        public JsonSerializerSettings Create()
        {
            return new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd hh:mm"
            };
        }
    }
}
