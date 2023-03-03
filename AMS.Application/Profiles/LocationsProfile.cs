using AMS.Application.DTOs.Location;
using AMS.Domain.Helpers;

namespace AMS.Application.Profiles;

public class LocationsProfile:Profile
{
    public LocationsProfile()
    {
        CreateMap<Location, LocationForCreationDto>();
        CreateMap<Location, LocationDto>().ReverseMap();
        //CreateMap<PagedList<Location>, PagedList<LocationDto>>()
        //    .ForMember(dest => dest.CurrentPage, opt => opt.MapFrom(src => src.CurrentPage))
        //    .ForMember(dest => dest.HasNext, opt => opt.MapFrom(src => src.HasNext))
        //    .ForMember(dest => dest.HasPrevious, opt => opt.MapFrom(src => src.HasPrevious))
        //    .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
        //    .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages))
        //    .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount));
    }
}