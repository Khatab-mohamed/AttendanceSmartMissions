using AMS.Domain.Helpers;
using AMS.Domain.ResourceParameters.Attendances;

namespace AMS.Infrastructure.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    #region MyRegion


    private readonly ApplicationDbContext _context;
    public AttendanceRepository(ApplicationDbContext context) => _context = context;


    #endregion

    public async Task CreateAsync(Attendance attendance)
    {
        await  _context.Attendances.AddAsync(attendance);
    }

    public async Task<IEnumerable<Attendance>> GetMyAttendances(Guid userId)
    {
        var attendancesBeforePaging =  _context.Attendances
            .Include(a => a.Location)
            .Where(a => a.UserId == userId)
            .OrderBy(a => a.CreatedOn).ToList();

        /*if (!string.IsNullOrWhiteSpace(attendanceResourceParameters.Location))
        {
            // trim & ignore casing
            var locationQueryForWhereClause = attendanceResourceParameters.Location
                .Trim().ToLowerInvariant();
            
            attendancesBeforePaging= attendancesBeforePaging
                .Where(a => a.Location.Name.ToLowerInvariant().Contains(locationQueryForWhereClause));

        }*/
        
        
        return attendancesBeforePaging.ToList();


    }
    
    public IQueryable<Attendance> GetAttendances(AttendanceResourceParameters 
        attendanceResourceParameters)
    {
        
        var collection = _context.Attendances
                .Include(a=>a.Location)
            as IQueryable<Attendance>;



        if ((attendanceResourceParameters.SearchQuery is not null))
        { // trim & ignore casing
            var locationQueryForWhereClause = attendanceResourceParameters.SearchQuery
                .Trim().ToLowerInvariant();

            // get property mapping dictionary
            collection = collection
                .Where(a => a.Location.Name.Contains(locationQueryForWhereClause));

        }
        
        if ((attendanceResourceParameters.From.HasValue))
        {
            // get property mapping dictionary
            collection = collection
                .Where(a => a.CreatedOn.Date >= attendanceResourceParameters.From.Value.Date);

        }

        if ((attendanceResourceParameters.To.HasValue))
        {
            // get property mapping dictionary
            collection = collection
                .Where(a => a.CreatedOn.Date <= attendanceResourceParameters.To.Value.Date);
        }

        return collection;
    }

    public bool SaveAsync()
    {
        return (_context.SaveChanges() >= 0);
    }

}