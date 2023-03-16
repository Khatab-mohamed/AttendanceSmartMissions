namespace AMS.Application.Services.Attendance;

public class AttendanceService : IAttendanceService
{
    #region Constructor

    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IMapper _mapper;
    public AttendanceService(IAttendanceRepository attendanceRepository, IMapper mapper)
    {
        _attendanceRepository = attendanceRepository;
        _mapper = mapper;
    }

    #endregion


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

    public async Task<IEnumerable<AttendanceDto>> GetAttendance(Guid userId)
    {
       var attendances = await _attendanceRepository.GetAttendances(userId);
       var attendancesToReturn = _mapper.Map<IEnumerable<AttendanceDto>>(attendances);
       return attendancesToReturn;
    }
}