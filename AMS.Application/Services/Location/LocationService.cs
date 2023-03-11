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


    public async Task<IEnumerable<LocationDto>> GetLocations()
    {
        var locations = await _locationRepository.GetLocations();
        var locationsDto = _mapper.Map<IEnumerable< LocationDto >>(locations);
        return locationsDto;
    }

    public async Task<LocationDto> GetLocationAsync(Guid id)
    {
        var location = await _locationRepository.GetAsync(id);
        var locationDto =  _mapper.Map<LocationDto>(location);
        return locationDto;
    }

    public async Task<LocationDto> AddAsync(CreationLocationDto creationLocation)
    {
        var locationEntity = _mapper.Map<Domain.Entities.Location>(creationLocation);

        locationEntity.CreatedOn = DateTime.UtcNow;
        await _locationRepository.CreateLocation(locationEntity);
        
        var result = _locationRepository.SaveAsync();
            return  _mapper.Map<LocationDto>(locationEntity);
    }

    public bool UpdateLocationAsync(UpdateLocationDto location)
    {
        if (location == null) 
            throw new ArgumentNullException(nameof(location));
        var  locationToAdd=   _mapper.Map<Domain.Entities.Location>(location);
        _locationRepository.UpdateLocation(locationToAdd);
        return _locationRepository.SaveAsync();
    }


    public bool SaveAsync()
    {
        return _locationRepository.SaveAsync();
    }

    public Task DeleteLocation(Guid locationId)
    {
        _locationRepository.DeleteLocation(locationId);

        if (!_locationRepository.SaveAsync())
            throw new Exception($"Deleting creationLocation {locationId} failed on save.");
        
        return Task.CompletedTask;
    }
    public bool IsExists(Guid locationId)
    {
        return _locationRepository.IsExist(locationId);
    }



    /*public LocationDto GetLocation(Guid locationId)
    {

        var creationLocation = _locationRepository.GetLocation(locationId);
        var locationToReturn = _mapper.Map<LocationDto>(creationLocation);
        return locationToReturn;
    }

   

  */
}