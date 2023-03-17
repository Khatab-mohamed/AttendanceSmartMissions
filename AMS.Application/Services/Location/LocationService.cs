using AMS.Domain.Entities.Locations;

namespace AMS.Application.Services.Location;

public class LocationService : ILocationService
{
    #region Constructor

    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public LocationService(
        ILocationRepository locationRepository,
        IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> IsExistsAsync(Guid locationId)
    {
        return await _locationRepository.IsExistAsync(locationId);
    }
    
    public async Task<IEnumerable<LocationDto>> GetLocations()
    {
        var locations = await _locationRepository.GetAsync();
        var locationsDto = _mapper.Map<IEnumerable< LocationDto >>(locations);
        return locationsDto;
    }

    public async Task<LocationDto> GetAsync(Guid id)
    {
        var location = await _locationRepository.GetAsync(id);
        var locationDto =  _mapper.Map<LocationDto>(location);
        return locationDto;
    }

    public async Task<bool> AddAsync(CreationLocationDto creationLocation)
    {
        var locationEntity = _mapper.Map<Domain.Entities.Location>(creationLocation);

        locationEntity.CreatedOn = DateTime.UtcNow;
        _locationRepository.Add(locationEntity);
        
      return await _locationRepository.SaveAsync();
    }

    public async Task<bool> UpdateLocationAsync(UpdateLocationDto? location)
    {
        if (location is null) 
            throw new ArgumentNullException(nameof(location));
        var locationToAdd = await _locationRepository.GetAsync(location.Id);
        if (locationToAdd != null)
        {
            locationToAdd.Name = location.Name;
            locationToAdd.Latitude= location.Latitude;
            locationToAdd.Longitude= location.Longitude;
            locationToAdd.Longitude = location.Longitude;
            locationToAdd.IsPublic = location.IsPublic;
            locationToAdd.StartDate = location.StartDate;
            locationToAdd.EndDate = location.EndDate;
            locationToAdd.AllowedDistance = location.AllowedDistance;

            _locationRepository.Update(locationToAdd);
        }

        return await _locationRepository.SaveAsync();
    }

    public async Task<IEnumerable<LocationDto>> GetUsersLocation(Guid userId)
    {
        var locations = await _locationRepository.GetUserLocations(userId);
        var locationsDto = _mapper.Map<IEnumerable<LocationDto>>(locations);
        return locationsDto;
    }

    public async Task<bool> AddUserLocationAsync(UserLocationDto userLocationDto)
    { 
        var to =  _mapper.Map<UserLocation>(userLocationDto);
        await _locationRepository.AddUserLocationAsync(to);
        return await _locationRepository.SaveAsync();
    }


    public async Task<bool> DeleteAsync(Guid locationId)
    {
        _locationRepository.Delete(locationId);

        return await _locationRepository.SaveAsync();
    }
    
}