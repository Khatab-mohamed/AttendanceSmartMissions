namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class IncidentsController : ControllerBase
{
    #region Constructor
    private readonly IIncidentService 
        _incidentService;
    public IncidentsController(IIncidentService incidentsService) => _incidentService = incidentsService;

    #endregion



    [HttpGet]
    public async Task<IActionResult> GetIncident()
    {
       var incident = await _incidentService.GetAll();
       return Ok(incident);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetIncidentType(Guid id)
    {
       var type = _incidentService.GetAsync(id);
       if (type is null)
           return NotFound(new ResponseDto { Status = "Failed", Message = "Incident Not Found" });

       return Ok(type);
    }

    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> CreateIncident(CreateIncidentDto creationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Can not Add This Incident" });


        var result = await _incidentService.AddAsync(creationDto)
            .ConfigureAwait(false);

        if (!result)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Fail on save Incident" });


        return Ok(new ResponseDto { Status = "Success", Message = $"Incident Added Successfully" });
    }
    
    [HttpPut]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> UpdateIncident(IncidentDto incidentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid Incident");


        var location = await _incidentService.GetAsync(incidentDto.Id);
        if (location is null)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Incident does not exists" });
        var result = await _incidentService.UpdateTypeAsync(incidentDto);

        if (!result)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Updating Failed on save" });


        return Ok(new ResponseDto { Status = "Success", Message = $"Incident Updated Successfully" });
    }


    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> DeleteIncident(Guid id)
    {
        var incidentTypeDto = await _incidentService.GetAsync(id); 
        if (incidentTypeDto is null)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Incident does not exists" });

        var result = await _incidentService.DeleteAsync(id);

        if (!result)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Can not Delete This Incident" });


        return Ok(new ResponseDto { Status = "Success", Message = $"Incident Deleted Successfully" });
    }


}