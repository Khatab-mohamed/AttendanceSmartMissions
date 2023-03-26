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
        .ForMember(u => u.Locations ,m =>m.MapFrom(s => s.UserLocations.Select(x=>x.Location.Name).ToList()))
            .IgnoreAllPropertiesWithAnInaccessibleSetter().ReverseMap();
    }
    
}