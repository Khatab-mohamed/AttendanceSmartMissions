using AMS.Application.DTOs.Incident.IncidentTypes;

namespace AMS.Application.Profiles;

public class IncidentProfile : Profile
{
    public IncidentProfile()
    {
        CreateMap<IncidentType, IncidentTypeDto>()
            .ForMember(d => d.Id,
                m => m.MapFrom(s => s.Id))
            .ForMember(d => d.Name,
                m => m.MapFrom(s => s.Name))
            .ReverseMap();
        
        CreateMap<CreationIncidentTypeDto,IncidentType>()
            .ForMember(d => d.Name,
                m => m.MapFrom(s => s.Name));

        CreateMap<CreateIncidentDto, Incident>()
            .ForMember(i => i.Title,
                s => s.MapFrom(c => c.Title))
            .ForMember(i => i.Description,
                c => c.MapFrom(dto => dto.Description))
            .ForMember(i => i.LocationId,
                c => c.MapFrom(dto => dto.LocationId))
            .ForMember(i => i.TypeId,
                c => c.MapFrom(dto => dto.TypeId));
        
        CreateMap<Incident, IncidentDto>()
            .ForMember(i => i.Id,
                s => s.MapFrom(c => c.Id))
            .ForMember(i => i.Title,
                s => s.MapFrom(c => c.Title))
            .ForMember(i => i.Description,
                c => c.MapFrom(dto => dto.Description))
            .ForMember(i => i.LocationId,
                c => c.MapFrom(dto => dto.LocationId))
            .ForMember(i => i.TypeId,
                c => c.MapFrom(dto => dto.TypeId));

        CreateMap<Incident, IncidentToReturnDto>()
            .ForMember(i => i.Id,
                s => s.MapFrom(c => c.Id))
            .ForMember(i => i.Title,
                s => s.MapFrom(c => c.Title))
            .ForMember(i => i.Description,
                c => c.MapFrom(dto => dto.Description))
            .ForMember(i => i.Description,
                c => c.MapFrom(dto => dto.Description))
            .ForMember(i => i.LocationName,
                s => s.MapFrom(s => s.Location.Name))
            .ForMember(i => i.TypeName,
                c => c.MapFrom(dto => dto.IncidentType.Name))
            .ForMember(i => i.UserName,
                c => c.MapFrom(dto => dto.User.FullName))
            .ForMember(i => i.CreatedOn,
                c => c.MapFrom(dto => dto.CreatedOn));

    }
}