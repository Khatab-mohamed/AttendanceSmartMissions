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

}