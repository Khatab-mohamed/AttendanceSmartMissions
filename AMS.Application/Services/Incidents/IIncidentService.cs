namespace AMS.Application.Services.Incidents;
public interface IIncidentService

{
    Task<IEnumerable<IncidentToReturnDto>> GetAll();
    Task<IncidentToReturnDto> GetAsync(Guid id);
    Task<bool> AddAsync(CreateIncidentDto createIncidentDto);
    Task<bool> UpdateTypeAsync(IncidentDto incidentDto);
    Task<bool> DeleteAsync(Guid typeId);
}