﻿namespace AMS.Application.Services.Attendance;

public interface IAttendanceService
{
    Task<bool> CrateAttendance(Guid userId, CreateAttendanceDto attendanceDtoDto);
    Task<IEnumerable<AttendanceDto>> GetAttendance(AttendanceResourceParameters attendanceResourceParameters);
}