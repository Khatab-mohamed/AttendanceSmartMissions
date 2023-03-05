using AMS.Application.DTOs.Location;
using AMS.Application.Services.Location;

namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LocationsController : ControllerBase
{
    private  readonly  ILocationService _locationService;
    public LocationsController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLocation()
    {
        var locations =   await _locationService.GetLocations().ConfigureAwait(false);

        return Ok(locations);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateLocation(LocationForCreationDto locationDto)
    {
        if (locationDto is null) return BadRequest("Invalid Location");

        var location = await _locationService.AddAsync(locationDto).ConfigureAwait(false);

        return Ok(location);
    }

    [HttpDelete("{id:guid}")]
    public  IActionResult DeleteLocation([FromHeader]Guid id)
    { 
        var result = _locationService.DeleteLocation(id);

        return Ok();
    }

}