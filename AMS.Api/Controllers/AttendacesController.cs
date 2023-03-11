using AMS.Application.DTOs.Attendance;
using System.Security.Claims;
using AMS.Application.Services.Attendance;

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
        public async Task<IActionResult> Post(CreateAttendance attendance)
        {
            if (attendance is null)
                return BadRequest(new { Message = "Check The Location Please" });
            
            var userId = GetCurrentUserId();
            
            var result =  await _attendanceService.CrateAttendance(userId, attendance);

            if (result)
            {
                return CreatedAtRoute("GetRoute", new{});
            }

            return BadRequest(new ResponseDto{Status = "Failed",Message = "can not Create Location"});
        }
      
        private Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.FindFirstValue("userId") ?? string.Empty);
        }
    }
}
