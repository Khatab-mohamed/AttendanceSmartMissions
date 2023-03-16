namespace AMS.Application.Services.Attendance;

public interface IAttendanceService
{
    Task<bool> CrateAttendance(Guid userId, CreateAttendance attendanceDto);
    Task<IEnumerable<AttendanceDto>> GetAttendance(Guid userId);
}