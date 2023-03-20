namespace AMS.Domain.Interfaces;

public interface IAttendanceRepository
{
    Task CreateAsync(Attendance attendance);
    Task<IEnumerable<Attendance>> GetMyAttendances(Guid userId);
    IQueryable<Attendance> GetAttendances(AttendanceResourceParameters attendanceResourceParameters);
    bool SaveAsync();
}