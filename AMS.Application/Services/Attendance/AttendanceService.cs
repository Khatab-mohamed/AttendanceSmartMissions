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


    public async Task<bool> CrateAttendance(Guid userId, CreateAttendanceDto attendanceDtoDto)
    {
        var attendance = new Domain.Entities.Attendance
        {
            IsActive = true,
            AttendanceType = attendanceDtoDto.Type,
            UserId = userId,
            LocationId = attendanceDtoDto.LocationId,
            CreatedBy = userId,
            CreatedOn = DateTime.Now,
            ModifiedBy = userId,
            ModifiedOn = DateTime.Now,
        };

        
        await _attendanceRepository.CreateAsync(attendance);

        return _attendanceRepository.SaveAsync();
    }

    public async Task<IEnumerable<AttendanceDto>> GetAttendance(AttendanceResourceParameters attendanceResourceParameters)
    {
       var attendances = await _attendanceRepository
           .GetAttendances(attendanceResourceParameters);
       var attendancesToReturn = _mapper.Map<IEnumerable<AttendanceDto>>
           (attendances);
       return attendancesToReturn;
    }
}