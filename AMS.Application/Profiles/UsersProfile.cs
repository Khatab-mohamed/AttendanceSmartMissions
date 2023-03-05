namespace AMS.Application.Profiles;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<RegisterDto, User>().ForMember(d => d.UserName,
            m => m.MapFrom(s => s.Email));
        CreateMap<CreateRoleDto, IdentityRole>();
        CreateMap<UpdateRoleDto, IdentityRole>();
        CreateMap<IdentityRole, RoleModel>().ForMember(d => d.RoleName, m => m.MapFrom(s => s.Name));
    }
    
}