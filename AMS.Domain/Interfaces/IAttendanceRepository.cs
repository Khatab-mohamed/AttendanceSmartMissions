namespace AMS.Domain.Interfaces;

public interface IAttendanceRepository
{
    Task CreateAsync(Attendance attendance);
    bool SaveAsync();
}