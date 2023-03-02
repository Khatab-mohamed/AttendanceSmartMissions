using AMS.Domain.Helpers;
using AMS.Domain.Helpers.Locations;
using AMS.Domain.Interfaces;

namespace AMS.Application.Services.Location;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper; 
    public LocationService(ILocationRepository locationRepository,
        IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public PagedList<Domain.Entities.Location> GetLocations(LocationsResourceParameters locationsResourceParameters)
    { 
        var locations =  _locationRepository.GetLocations(locationsResourceParameters);
        // Try Map 
        // Todo
//         var mappedLocations =_mapper.Map<PagedList<LocationDto> >(locations);

        return locations;

    }

    public LocationDto GetLocation(Guid locationId)
    {

        var location = _locationRepository.GetLocation(locationId);
        var locationToReturn = _mapper.Map<LocationDto>(location);
        return locationToReturn;
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
    }
}