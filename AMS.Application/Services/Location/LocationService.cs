﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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
    public async Task<LocationDto> AddAsync(LocationForCreationDto location)
    {
        var locationEntity = _mapper.Map<Domain.Entities.Location>(location);

       locationEntity.CreatedOn = DateTime.UtcNow;
        await _locationRepository.CreateLocation(locationEntity);
        
        var result = _locationRepository.SaveAsync();
            return  _mapper.Map<LocationDto>(locationEntity);
    }


    public bool SaveAsync()
    {
        return _locationRepository.SaveAsync();
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
        if (!_locationRepository.SaveAsync())
            throw new Exception($"Deleting location {locationId} failed on save.");
        return Task.CompletedTask;
    }

  */
}