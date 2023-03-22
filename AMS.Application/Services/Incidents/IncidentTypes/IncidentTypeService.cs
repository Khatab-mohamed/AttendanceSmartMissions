using AMS.Application.DTOs.Incident.IncidentTypes;
using AMS.Domain.Entities;
using AMS.Domain.Interfaces;

namespace AMS.Application.Services.Incidents.IncidentTypes;

public class IncidentTypeService : IIncidentTypeService
{
    #region Constructor
    
    private readonly IIncidentsRepository _incidentsRepository;
    private readonly IMapper _mapper;
    public IncidentTypeService(IIncidentsRepository incidentsRepository, IMapper mapper)
    {
        _incidentsRepository = incidentsRepository;
        _mapper = mapper;
    }
    #endregion

    public async Task<IEnumerable<IncidentTypeDto>> GetIncidentTypes()
    {
        var incident = await _incidentsRepository.GetTypesAsync();
        var incidentToReturn = _mapper.Map<IEnumerable<IncidentTypeDto>>(incident);
        return incidentToReturn;
    }

    public async Task<IncidentTypeDto> GetAsync(Guid id)
    {
        var incidentType = await _incidentsRepository.GetTypeAsync(id);
        var incidentTypeDto = _mapper.Map<IncidentTypeDto>(incidentType);
        return incidentTypeDto;
    }

    public async Task<bool> AddAsync(CreationIncidentTypeDto creationIncidentTypeDto)
    {

        var entity = _mapper.Map<IncidentType>(creationIncidentTypeDto);

        _incidentsRepository.AddType(entity);

        return await _incidentsRepository.SaveAsync();
    }

    public async Task<bool> UpdateTypeAsync(IncidentTypeDto incidentTypeDto)
    {
        if (incidentTypeDto is null)
            throw new ArgumentNullException(nameof(incidentTypeDto));
        var incidentType = await _incidentsRepository.GetTypeAsync(incidentTypeDto.Id);
        if (incidentType != null)
        {
            incidentType.Name = incidentTypeDto.Name;
            _incidentsRepository.UpdateType(incidentType);
        }

        return await _incidentsRepository.SaveAsync();
    }

    public async Task<bool> DeleteAsync(Guid typeId)
    {
        _incidentsRepository.DeleteType(typeId);

        return await _incidentsRepository.SaveAsync();
    }


}