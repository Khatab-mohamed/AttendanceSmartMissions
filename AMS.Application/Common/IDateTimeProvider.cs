namespace AMS.Application.Common;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}