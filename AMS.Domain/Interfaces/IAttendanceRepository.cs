namespace AMS.Domain.Interfaces;

public interface IAttendanceRepository
{
    Task CreateAsync(Attendance attendance);
    Task<IEnumerable<Attendance>> GetAttendances(Guid userId);
    bool SaveAsync();
}