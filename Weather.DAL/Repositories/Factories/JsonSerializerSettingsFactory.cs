using Newtonsoft.Json;
using Weather.DAL.Abstractions;

namespace Weather.DAL.Repositories.Factories
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
