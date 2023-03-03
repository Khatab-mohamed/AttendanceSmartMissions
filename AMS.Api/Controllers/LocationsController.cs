using AMS.Application.DTOs.Location;

namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly IUrlHelper _urlHelper;
    private readonly ILocationService _locationService;
    public LocationsController(IUrlHelper urlHelper,
        ILocationService locationService)
    {
        _urlHelper = urlHelper;
        _locationService = locationService;
    }


    [HttpPut]
    public IActionResult UpdateLocation([FromBody] LocationForCreationDto location)
    {
        if (location is null)
            return BadRequest();



        var addedLocation = _locationService.AddLocation(location);

        if (!_locationService.Save())
            throw new Exception("Creating an location failed on save.");



        return CreatedAtRoute("GetLocation",
            new { id = addedLocation.Id },
            addedLocation);
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteLocation(Guid id)
    {
        var exists = _locationService.LocationExists(id);
        
        
        if (exists is false) return NotFound();

        await _locationService.DeleteLocation(id);
        return NoContent();
    }

    #region Done

    [HttpPost]
    public IActionResult CreateLocation([FromBody] LocationForCreationDto location)
    {
        if (location is null)
            return BadRequest();



        var addedLocation = _locationService.AddLocation(location);

        if (!_locationService.Save())
            throw new Exception("Creating an location failed on save.");



        return CreatedAtRoute("GetLocation",
            new { id = addedLocation.Id },
            addedLocation);
    }


    [HttpGet(Name = "GetLocations")]
    public IActionResult GetLocations(LocationsResourceParameters locationsResourceParameters)
    {
        var locationsFromRepo = _locationService.GetLocations(locationsResourceParameters);
        var previousPageLink = locationsFromRepo.HasPrevious ?
            CreateLocationResourceUri(locationsResourceParameters,
                ResourceUriType.PreviousPage) : null;

        var nextPageLink = locationsFromRepo.HasNext ?
            CreateLocationResourceUri(locationsResourceParameters,
                ResourceUriType.NextPage) : null;

        var paginationMetadata = new
        {
            totalCount = locationsFromRepo.TotalCount,
            pageSize = locationsFromRepo.PageSize,
            currentPage = locationsFromRepo.CurrentPage,
            totalPages = locationsFromRepo.TotalPages,
            previousPageLink = previousPageLink,
            nextPageLink = nextPageLink
        };

        Response.Headers.Add("X-Pagination",
            Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));


        return Ok(locationsFromRepo);
    }

    [HttpGet("{id:guid}", Name = "GetLocation")]
    public IActionResult GetLocation(Guid id)
    {
        var location = _locationService.GetLocation(id);

        if (location is null)
            return NotFound();

        return Ok(location);
    }

    private string? CreateLocationResourceUri(
        LocationsResourceParameters locationsResourceParameters,
        ResourceUriType type)
    {
        switch (type)
        {
            case ResourceUriType.PreviousPage:
                return _urlHelper.Link("GetLocations",
                    new
                    {
                        searchQuery = locationsResourceParameters.SearchQuery,
                        pageNumber = locationsResourceParameters.PageNumber - 1,
                        pageSize = locationsResourceParameters.PageSize
                    });
            case ResourceUriType.NextPage:
                return _urlHelper.Link("GetLocations",
                    new
                    {
                        searchQuery = locationsResourceParameters.SearchQuery,
                        pageNumber = locationsResourceParameters.PageNumber + 1,
                        pageSize = locationsResourceParameters.PageSize
                    });

            default:
                return _urlHelper.Link("GetLocations",
                    new
                    {
                        searchQuery = locationsResourceParameters.SearchQuery,
                        pageNumber = locationsResourceParameters.PageNumber,
                        pageSize = locationsResourceParameters.PageSize
                    });
        }
    }



    #endregion


}