namespace Weather.DAL.Data.WeatherAPIResponse
{
    public sealed class WeatherResponseData
    {
        public IReadOnlyCollection<WeatherResponse> WeatherForecastData { get; init; } = new List<WeatherResponse>();
    }
}