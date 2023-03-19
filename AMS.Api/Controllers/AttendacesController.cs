using AMS.Domain.ResourceParameters.Attendances;

namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Authorize]
public class AttendancesController : ControllerBase
{
    #region Constructor

    private readonly IAttendanceService _attendanceService;
    public AttendancesController(IAttendanceService attendanceService) => _attendanceService = attendanceService;

    #endregion

    [HttpPost]
    public async Task<IActionResult> Create(CreateAttendanceDto attendanceDto)
    {
        if (attendanceDto is null)
            return BadRequest(new ResponseDto {Status= "Failed",  Message = "Check The Location Please" });
            
        var userId = GetCurrentUserId();
            
        var result =  await _attendanceService.CrateAttendance(userId, attendanceDto);

        if (result) 
            return Ok(new ResponseDto { Status = "Success", Message = "Your Attendance Submitted Successfully" });
                
        return BadRequest(new ResponseDto { Status = "Failed", Message = "Your Attendance Failed" });
    }


    [HttpGet]
    public async Task<IActionResult> GeAttendances()
    {
        var userId = GetCurrentUserId();


        var result =  await _attendanceService.GetAttendance(userId);
        if (result is null)
            return NoContent();
        return Ok(result);

    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Super Admin")]
    public  IActionResult GeAttendances(Guid id, [FromQuery] AttendanceResourceParameters attendanceResourceParameters)
    {
        var result =  _attendanceService.GetAttendance(id,attendanceResourceParameters);

        return Ok(result);
    }

    private Guid GetCurrentUserId()
    {
        return Guid.Parse(HttpContext.User.FindFirstValue("userId") ?? string.Empty);
    }
}