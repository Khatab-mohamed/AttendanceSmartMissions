using AMS.Domain.Entities.Authentication;
using AMS.Domain.Entities;

namespace AMS.Application.Profiles;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<RegisterDto, User>().ForMember(d => d.UserName,
            m => m.MapFrom(s => s.Email));
        CreateMap<RoleDto, IdentityRole>();
        CreateMap<UpdateRoleDto, IdentityRole>();
        CreateMap<IdentityRole, RoleModel>()
            .ForMember(d => d.RoleName, m => m.MapFrom(s => s.Name));

        CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.IDNumber, opt => opt.MapFrom(src => src.IDNumber))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                //.ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles))
                .ForMember(dest => dest.Locations, opt => opt.MapFrom(src => src.UserLocations
                .Select(ul => new UserLocationsDto { Id = ul.LocationId, Name = ul.Location.Name }).ToList()));
    }
    
}