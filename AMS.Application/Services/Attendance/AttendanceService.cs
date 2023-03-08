namespace AMS.Application.Services.Attendance;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;
    public AttendanceService(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }
    public async Task<bool> CrateAttendance(Guid userId, CreateAttendance attendanceDto)
    {
        var attendance = new Domain.Entities.Attendance
        {
            IsActive = true,
            AttendanceType = attendanceDto.Type,
            UserId = userId,
            LocationId = attendanceDto.LocationId,
            CreatedBy = userId,
            CreatedOn = DateTime.Now,
            ModifiedBy = userId,
            ModifiedOn = DateTime.Now,
        };

        
        await _attendanceRepository.CreateAsync(attendance);

        return _attendanceRepository.SaveAsync();
    }
}