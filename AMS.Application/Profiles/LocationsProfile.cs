namespace AMS.Application.Profiles;

public class LocationsProfile : Profile
{
    public LocationsProfile()
    {
        CreateMap<LocationDto,Location>()
            .ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
            .ForMember(d =>d.Name, m => m.MapFrom(s => s.Name)).ReverseMap();
        CreateMap<LocationForCreationDto, Location>().ReverseMap();

    }
    
}