using AMS.Domain.ResourceParameters.Attendances;

namespace AMS.Domain.Interfaces;

public interface IAttendanceRepository
{
    Task CreateAsync(Attendance attendance);
    Task<IEnumerable<Attendance>> GetAttendances(AttendanceResourceParameters attendanceResourceParameters);
    bool SaveAsync();
}