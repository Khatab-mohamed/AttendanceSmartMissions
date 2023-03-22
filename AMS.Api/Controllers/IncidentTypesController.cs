namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Super Admin,Admin")]
public class IncidentTypesController : ControllerBase
{
    #region Constructor
    private readonly IIncidentTypeService _incidentTypeService;
    public IncidentTypesController(IIncidentTypeService incidentsService) => _incidentTypeService = incidentsService;

    #endregion



    [HttpGet]
    [Authorize(Roles = "Super Admin,Admin,User")]
    public async Task<IActionResult> GetIncidentTypes()
    {
       var types = await _incidentTypeService.GetIncidentTypes();
       return Ok(types);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetIncidentType(Guid id)
    {
       var type = await _incidentTypeService.GetAsync(id);
       if (type is null)
           return NotFound(new ResponseDto { Status = "Failed", Message = "Incident Type Not Found" });

       return Ok(type);
    }

    [HttpPost]
    public async Task<IActionResult> CreateIncidentType(CreationIncidentTypeDto creationType)
    {
        if (creationType is null)
            return BadRequest("Invalid Type");


        var result = await _incidentTypeService.AddAsync(creationType)
            .ConfigureAwait(false);

        if (!result)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Fail on save Incident Type" });


        return Ok(new ResponseDto { Status = "Success", Message = $"Incident Type Added Successfully" });
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateIncidentType(IncidentTypeDto incidentTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid Incident Type");


        var location = await _incidentTypeService.GetAsync(incidentTypeDto.Id);
        if (location is null)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Incident does not exists" });
        var result = await _incidentTypeService.UpdateTypeAsync(incidentTypeDto);

        if (!result)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Updating Failed on save" });


        return Ok(new ResponseDto { Status = "Success", Message = $"Incident Type Updated Successfully" });
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteIncidentType(Guid id)
    {
        var incidentTypeDto = await _incidentTypeService.GetAsync(id); 
        if (incidentTypeDto is null)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Incident does not exists" });

        var result = await _incidentTypeService.DeleteAsync(id);

        if (!result)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Can not Delete This Incident Type" });


        return Ok(new ResponseDto { Status = "Success", Message = $"Incident Deleted Successfully" });
    }


}