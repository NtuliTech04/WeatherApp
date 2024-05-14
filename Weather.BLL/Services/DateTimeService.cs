using Weather.BLL.Services.IService;

namespace Weather.BLL.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
