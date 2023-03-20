using AMS.Domain.Helpers;

namespace AMS.Application.Profiles;

public class AttendancesProfile : Profile
{
    public AttendancesProfile()
    {
        CreateMap<Attendance, AttendanceDto>()
            .ForMember(d => d.Id, 
                m => m.MapFrom(s => s.Id))
            .ForMember(d => d.UserId,
                m => m.MapFrom(s => s.UserId))
            .ForMember(d => d.LocationId,
                m => m.MapFrom(s => s.LocationId))
            .ForMember(d => d.Type, 
                m => m.MapFrom(s => s.AttendanceType))
            .ForMember(d => d.CreatedOn, 
                m => m.MapFrom(s => s.CreatedOn))
            .ForMember(d => d.Location, 
                m => m.MapFrom(s => s.Location.Name))
            .IgnoreAllPropertiesWithAnInaccessibleSetter();



    }
    
}