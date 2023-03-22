namespace AMS.Infrastructure.Repositories;

public class IncidentsRepository : IIncidentsRepository
{
    #region Constructor

    private readonly ApplicationDbContext _context;
    public IncidentsRepository(ApplicationDbContext context) => _context = context;

    #endregion

    #region IncidentTypes


    public async Task<IEnumerable<IncidentType>> GetTypesAsync()
    {
        return await _context.IncidentTypes.ToListAsync();
    }

    public async Task<IncidentType?> GetTypeAsync(Guid typeId)
    {
        var entity = await _context.IncidentTypes.FindAsync(typeId);
        return entity;

    }

    public void AddType(IncidentType type)
    {
        _context.IncidentTypes.Add(type);
    }

    public void UpdateType(IncidentType type)
    {
        _context.IncidentTypes.Attach(type);
    }

    public void DeleteType(Guid typeId)
    {
        var incidentType = _context.IncidentTypes.FirstOrDefault(l => l.Id == typeId);

        if (incidentType != null) _context.IncidentTypes.Remove(incidentType);
    }




    #endregion


    #region Incidents

    public async Task<IEnumerable<Incident>> GetIncidentsAsync()
    {
        return await _context
            .Incidents
            .Include(u =>u.User)
            .Include(u =>u.Location)
            .Include(u =>u.IncidentType)
            .ToListAsync();
    }

    public async Task<Incident?> GetIncidentAsync(Guid id)
    {
        var entity = await _context.Incidents
            .Include(u => u.User)
            .Include(u => u.Location)
            .Include(u => u.IncidentType).FirstOrDefaultAsync(i =>i.Id == id);
        return entity;
    }

    public void AddIncident(Incident incident)
    {
        _context.Incidents.Add(incident);
    }

    public void UpdateIncident(Incident incident)
    {
        _context.Incidents.Attach(incident);
    }


    public void DeleteIncident(Guid incident)
    {
        var incidentType = _context.Incidents.FirstOrDefault(l => l.Id == incident);

        if (incidentType != null) _context.Incidents.Remove(incidentType);
    }

    #endregion

    public async Task<bool> SaveAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}