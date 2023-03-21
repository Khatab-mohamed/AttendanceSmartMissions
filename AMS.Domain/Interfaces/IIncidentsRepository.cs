namespace AMS.Domain.Interfaces;

public interface IIncidentsRepository
{
    // IncidentTypes
    Task<IEnumerable<IncidentType>> GetTypesAsync();
    Task<IncidentType?> GetTypeAsync(Guid typeId);
    void AddType(IncidentType type);
    void UpdateType(IncidentType type);
    void DeleteType(Guid typeId);


    // Incidents
    Task<IEnumerable<Incident>> GetIncidentsAsync();
    Task<Incident?> GetIncidentAsync(Guid incident);
    void AddIncident(Incident incident);
    void UpdateIncidentType(Incident incident);
    void DeleteIncident(Guid incident);
}