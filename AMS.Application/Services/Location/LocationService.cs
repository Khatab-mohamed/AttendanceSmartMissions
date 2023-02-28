using AMS.Domain.Interfaces;
using AutoMapper;

namespace AMS.Application.Services.Location;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper; 
    public LocationService(ILocationRepository locationRepository, IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public IEnumerable<LocationDto> GetLocations()
    {
      var locations =  _locationRepository.GetLocations();
      var locationsToReturn= _mapper.Map<IEnumerable<LocationDto>>(locations);
      return locationsToReturn;
    }

    public LocationDto GetLocations(Guid locationId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<LocationDto> Locations(IEnumerable<Guid> locationsIds)
    {
        throw new NotImplementedException();
    }

    public Task AddLocation(LocationForCreationDto locationDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLocation(LocationDto locationDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLocation(LocationDto locationDto)
    {
        throw new NotImplementedException();
    }

    public bool LocationExists(Guid locationId)
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }
}