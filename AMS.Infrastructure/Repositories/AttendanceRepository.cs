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

    public async Task<IEnumerable<Attendance>> GetAttendances(AttendanceResourceParameters  attendanceResourceParameters)
    {
        var attendancesBeforePaging =  _context.Attendances
            .Where(a => a.UserId == attendanceResourceParameters.UserId)
            .OrderBy(a => a.CreatedOn).Include(a => a.Location).AsQueryable();

        if (!string.IsNullOrWhiteSpace(attendanceResourceParameters.Location))
        {
            // trim & ignore casing
            var locationQueryForWhereClause = attendanceResourceParameters.Location
                .Trim().ToLowerInvariant();
            
            attendancesBeforePaging= attendancesBeforePaging
                .Where(a => a.Location.Name.ToLowerInvariant().Contains(locationQueryForWhereClause));

        }
        
        
        return attendancesBeforePaging;


    }

    public bool SaveAsync()
    {
        return (_context.SaveChanges() >= 0);
    }

}