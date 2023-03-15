namespace AMS.Application.Services.Location;

public class LocationService : ILocationService
{
    #region Constructor

    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;
    public LocationService(
        ILocationRepository locationRepository,
        IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
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
        var  locationToAdd=   _mapper.Map<Domain.Entities.Location>(location);
        _locationRepository.Update(locationToAdd);
        return await _locationRepository.SaveAsync();
    }


    public async Task<bool> DeleteAsync(Guid locationId)
    {
        _locationRepository.Delete(locationId);

        return await _locationRepository.SaveAsync();
    }
    
}