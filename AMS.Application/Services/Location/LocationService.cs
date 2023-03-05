namespace AMS.Application.Services.Location;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
   // private readonly IMapper _mapper; 
    public LocationService(ILocationRepository locationRepository
        /*IMapper mapper*/)
    {
        _locationRepository = locationRepository;
     //   _mapper = mapper;
    }

    public IEnumerable<LocationDto> GetLocations()
    {
        var locations = new List<LocationDto>();
        var x= _locationRepository.GetLocations();
        return locations;
    }

    /*public LocationDto GetLocation(Guid locationId)
    {

        var location = _locationRepository.GetLocation(locationId);
        var locationToReturn = _mapper.Map<LocationDto>(location);
        return locationToReturn;
    }

    public bool LocationExists(Guid locationId)
    {
        return _locationRepository.IsExist(locationId);
    }

    public Task DeleteLocation(Guid locationId)
    {
        _locationRepository.DeleteLocation(locationId);
        if (!_locationRepository.Save())
            throw new Exception($"Deleting location {locationId} failed on save.");
        return Task.CompletedTask;
    }

    public LocationDto AddLocation(LocationForCreationDto location)
    { 
        var locationEntity = _mapper.Map<Domain.Entities.Location>(location);
        _locationRepository.CreateLocation(locationEntity);
        
        if (!_locationRepository.Save())
            throw new Exception("Creating an Location failed on save.");
        
        var addLocation = _mapper.Map<LocationDto>(locationEntity);

        return addLocation;

    }


    public bool Save()
    {
        return _locationRepository.Save();
    }*/
}