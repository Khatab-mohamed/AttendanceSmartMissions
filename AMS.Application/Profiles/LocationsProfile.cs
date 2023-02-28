using AutoMapper;
namespace AMS.Application.Profiles;

public class LocationsProfile:Profile
{
    public LocationsProfile()
    {
        CreateMap<Location, LocationForCreationDto>();
        CreateMap<Location, LocationDto>();
            
        
    }
}