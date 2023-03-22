namespace AMS.Application.Services.Incidents;
public class IncidentService : IIncidentService
{
    #region Constructor
    private readonly IIncidentsRepository _incidentsRepository;
    private readonly IMapper _mapper;
    public IncidentService(IIncidentsRepository incidentsRepository, 
        IMapper mapper)
    {
        _incidentsRepository = incidentsRepository;
        _mapper = mapper;
    }
    #endregion

    public async Task<IEnumerable<IncidentToReturnDto>> GetAll()
    {
        var incidents = await _incidentsRepository.GetIncidentsAsync();
        var incidentToReturn = _mapper.Map<IEnumerable<IncidentToReturnDto>>(incidents);
        return incidentToReturn;
    }

    public async Task<IncidentToReturnDto> GetAsync(Guid id)
    {
        var source = await _incidentsRepository.GetTypeAsync(id);
        var incidentDto = _mapper.Map<IncidentToReturnDto>(source);
        return incidentDto;
    }

    public async Task<bool> AddAsync(CreateIncidentDto createIncidentDto)
    {
        var entity = _mapper.Map<Incident>(createIncidentDto);

        _incidentsRepository.AddIncident(entity);

        return await _incidentsRepository.SaveAsync();
    }

    public async Task<bool> UpdateTypeAsync(IncidentDto incidentDto)
    {
        if (incidentDto is null)
            throw new ArgumentNullException(nameof(incidentDto));
        var incident = await _incidentsRepository.GetIncidentAsync(incidentDto.Id);
        if (incident != null)
        {
            incident.Title = incidentDto.Title;
            incident.Description = incidentDto.Description;
        }

        if (incident != null) 
            _incidentsRepository.UpdateIncident(incident);

        return await _incidentsRepository.SaveAsync();
    }

    public async Task<bool> DeleteAsync(Guid typeId)
    {
        _incidentsRepository.DeleteIncident(typeId);

        return await _incidentsRepository.SaveAsync();
    }
}