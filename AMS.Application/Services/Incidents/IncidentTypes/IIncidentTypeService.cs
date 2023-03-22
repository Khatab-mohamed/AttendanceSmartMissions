using AMS.Application.DTOs.Incident.IncidentTypes;

namespace AMS.Application.Services.Incidents.IncidentTypes;

public interface IIncidentTypeService
{
    Task<IEnumerable<IncidentTypeDto>> GetIncidentTypes();
    Task<IncidentTypeDto> GetAsync(Guid id);
    Task<bool> AddAsync(CreationIncidentTypeDto creationIncidentTypeDto);
    Task<bool> UpdateTypeAsync(IncidentTypeDto incidentTypeDto);
    Task<bool> DeleteAsync(Guid typeId);
}