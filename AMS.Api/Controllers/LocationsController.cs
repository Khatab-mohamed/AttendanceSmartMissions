using System.Security.Claims;
using AMS.Application.DTOs.Location;
using AMS.Application.Services.Location;


namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Authorize(Roles = "Super Admin,Admin")]
public class LocationsController : ControllerBase
{
    #region Constructor

    private readonly ILocationService _locationService;
    public LocationsController(ILocationService locationService)
    {
        _locationService = locationService;
    }


    #endregion

    [HttpGet]
    public async Task<IActionResult> GetLocation()
    {
        var locations =   await _locationService.GetLocations().ConfigureAwait(false);

        return Ok(locations);
    }

    [HttpGet("{id:guid}")]

    public async Task<IActionResult> GetLocationById(Guid id)
    {
        var exists = await  _locationService.IsExistsAsync(id);
        if (!exists)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Location Not Found" });

        var location = await _locationService.GetAsync(id);

        return Ok(location);
    }


    [HttpPost]
    public async Task<IActionResult> CreateLocation(CreationLocationDto creationLocationDto)
    {
        if (creationLocationDto is null) 
            return BadRequest("Invalid Location");
       

        var result = await _locationService.AddAsync(creationLocationDto).ConfigureAwait(false);

        if (!result)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Can not Add This Location" });


        return Ok(new ResponseDto { Status = "Success", Message = $"Location Added Successfully" });
    }
    
    
    [HttpPut]
    public async Task<IActionResult> UpdateLocation(UpdateLocationDto? locationDto)
    {
        if (locationDto is null) 
            return BadRequest("Invalid Location");


        var location = await  _locationService.IsExistsAsync(locationDto.Id);
        if (!location)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Location does not exists" });
        var result = await _locationService.UpdateLocationAsync(locationDto);
        
        if (!result)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Updating Failed on save" });

     
        return Ok( new ResponseDto{Status = "Success",Message = $"Location Updated Successfully"}); 
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteLocation(Guid id)
    {

        var location = await _locationService.IsExistsAsync(id);
        if (!location)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Location does not exists" });

        var result = await _locationService.DeleteAsync(id);

        if (!result)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Can not Delete This Location" });


        return Ok(new ResponseDto { Status = "Success", Message = $"Location Deleted Successfully" });
    }
    
    
    [HttpGet("User")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserLocations()
    {
        var id = GetCurrentUserId();
        var locations = await _locationService.GetUsersLocation(id);
        return Ok(locations);
    }


    [HttpPost("AddUserLocation")]
    public async Task<IActionResult> RegisterUserLocation(UserLocationDto userLocationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Can not Assign this Location for the Current User" });

        // Check for location existence
        var location = await _locationService.IsExistsAsync(userLocationDto.LocationId);
        if (!location)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Location does not exists" });


        var result = await _locationService.AddUserLocationAsync(userLocationDto);
        if (!result)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Adding User to the location failed" });


        return Ok(new ResponseDto { Status = "Success", Message = $"User Added Successfully to this location" });
    }

    [HttpDelete("RemoveUserLocation")]
    public async Task<IActionResult> RemoveUserLocation(UserLocationDto userLocationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Can not Assassin this Location for the Current User" });

        // Check for location existence
        var location = await _locationService.IsExistsAsync(userLocationDto.LocationId);
        if (!location)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Location does not exists" });


        var result = await _locationService.RemoveUserLocationAsync(userLocationDto);
        if (!result)
            return BadRequest(new ResponseDto { Status = "Failed", Message = "Deleting User to the location failed" });


        return Ok(new ResponseDto { Status = "Success", Message = $"User Deleted Successfully from this location" });
    }


    private Guid GetCurrentUserId()
    {
        return Guid.Parse(HttpContext.User.FindFirstValue("userId") ?? string.Empty);
    }

}