namespace AMS.Application.Services.Attendance
{
    public interface IAttendanceService
    {
        Task<bool> CrateAttendance(Guid userId, CreateAttendance attendanceDto);
    }
}
