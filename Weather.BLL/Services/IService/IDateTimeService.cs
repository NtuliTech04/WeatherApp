namespace Weather.BLL.Services.IService
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
        DateTime GetHumanDate(long timestamp);
    }
}
