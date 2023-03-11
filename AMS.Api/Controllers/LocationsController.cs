using AMS.Application.DTOs.Location;
using AMS.Application.Services.Location;


namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//[Authorize(Roles = "Super Admin")]
public class LocationsController : ControllerBase
{
    private  readonly  ILocationService _locationService;
    private readonly UserManager<User> _userManager; 
    public LocationsController(ILocationService locationService, UserManager<User> userManager)
    {
        _locationService = locationService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetLocation()
    {
        var locations =   await _locationService.GetLocations().ConfigureAwait(false);

        return Ok(locations);
    }

    [HttpGet("{id:guid}")]

    public async Task<IActionResult> GetLocationById(Guid id)
    {
        var exists =  _locationService.IsExists(id);
        if (!exists)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Location Not Found" });

        var location = await _locationService.GetLocationAsync(id);

        return Ok(location);
    }


    [HttpPost]
    public async Task<IActionResult> CreateLocation(LocationForCreationDto locationDto)
    {
        if (locationDto is null) 
            return BadRequest("Invalid Location");
       

        var location = await _locationService.AddAsync(locationDto).ConfigureAwait(false);

        return Ok(location);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteLocation(Guid id)
    {
        var locations = await _locationService.GetLocations();
        var result = _locationService.DeleteLocation(id);

        return Ok();
    }

}