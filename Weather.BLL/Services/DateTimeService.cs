using Weather.BLL.Services.IService;

namespace Weather.BLL.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;

        public DateTime GetHumanDate(long timestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime.ToLocalTime();
        }
    }
}
