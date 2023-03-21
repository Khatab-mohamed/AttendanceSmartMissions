namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Authorize]
public class AttendancesController : ControllerBase
{
    #region Constructor

    private readonly IAttendanceService _attendanceService;
   

    public AttendancesController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    
    }

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
    [Route("UserAttendance")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> GeAttendances()
    {
        var userId = GetCurrentUserId();


        var result = await _attendanceService.GetAttendance(userId);
        if (result is null)
            return NoContent();
        return Ok(result);

    }

    [HttpGet(Name = "GetAttendances")]
    [Authorize(Roles = "Admin,Super Admin")]
    public  IActionResult GeAttendances([FromQuery]AttendanceResourceParameters attendanceResourceParameters)
    {
        var result =  _attendanceService.GetAttendance(attendanceResourceParameters);
        
        
        /*var previousPageLink = result.HasPrevious ?
            CreateAttendancesResourceUri(attendanceResourceParameters,
                ResourceUriType.PreviousPage) : null;

        var nextPageLink = result.HasNext ?
            CreateAttendancesResourceUri(attendanceResourceParameters,
                ResourceUriType.NextPage) : null;*/

        var paginationMetadata = new
        {
            totalCount = result.TotalCount,
            pageSize = result.PageSize,
            currentPage = result.CurrentPage,
            totalPages = result.TotalPages
        };

        Response.Headers.Add("X-Pagination",
            Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

        return Ok(result);
    }

    private Guid GetCurrentUserId()
    {
        return Guid.Parse(HttpContext.User.FindFirstValue("userId") ?? string.Empty);
    }
    /*private string? CreateAttendancesResourceUri(
        AttendanceResourceParameters attendanceResourceParameters,
        ResourceUriType type)
    {
        switch (type)
        { 
            case ResourceUriType.PreviousPage:
                return _urlHelper.Link("GetAttendances",
                    new
                    {
                        from = attendanceResourceParameters.From,
                        to = attendanceResourceParameters.To,
                        pageNumber = attendanceResourceParameters.PageNumber - 1,
                        pageSize = attendanceResourceParameters.PageSize
                    });
            case ResourceUriType.NextPage:
                return _urlHelper.Link("GetAttendances",
                    new
                    {
                        from = attendanceResourceParameters.From,
                        to = attendanceResourceParameters.To,
                        pageNumber = attendanceResourceParameters.PageNumber + 1,
                        pageSize = attendanceResourceParameters.PageSize
                    });

            default:
                return _urlHelper.Link("GetAttendances",
                    new
                    {
                        from = attendanceResourceParameters.From,
                        to = attendanceResourceParameters.To,
                        pageNumber = attendanceResourceParameters.PageNumber,
                        pageSize = attendanceResourceParameters.PageSize
                    });
        }
    }*/

}