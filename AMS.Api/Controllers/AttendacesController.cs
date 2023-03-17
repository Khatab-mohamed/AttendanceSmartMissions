using AMS.Domain.ResourceParameters.Attendances;

namespace AMS.Api.Controllers
{
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


        [HttpGet(Name = "GetAttendances")]
        public async Task<IActionResult> GeAttendances([FromQuery]AttendanceResourceParameters attendanceResourceParameters)
        {
            var userId = GetCurrentUserId();
            var result =  await _attendanceService.GetAttendance(attendanceResourceParameters);
            if (result is null)
                return NoContent();
            return Ok(result);

        }
      
        private Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.FindFirstValue("userId") ?? string.Empty);
        }
    }
}
