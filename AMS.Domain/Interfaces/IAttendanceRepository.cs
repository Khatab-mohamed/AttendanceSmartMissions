namespace AMS.Domain.Interfaces;

public interface IAttendanceRepository
{
    Task CreateAsync(Attendance attendance);
    Task<IEnumerable<Attendance>> GetMyAttendances(Guid userId);
    PagedList<Attendance> GetAttendances(Guid locationId, AttendanceResourceParameters attendanceResourceParameters);
    bool SaveAsync();
}