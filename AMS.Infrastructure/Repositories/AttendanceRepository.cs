namespace AMS.Infrastructure.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    #region Constructor



    private readonly ApplicationDbContext _context;
    public AttendanceRepository(ApplicationDbContext context) => _context = context;


    #endregion

    public async Task CreateAsync(Attendance attendance)
    {
        await  _context.Attendances.AddAsync(attendance);
    }

    public Task<IEnumerable<Attendance>> GetMyAttendances(Guid userId)
    {
        var attendancesBeforePaging =  _context.Attendances
            .Include(a => a.Location)
            .Where(a => a.UserId == userId)
            .OrderBy(a => a.CreatedOn).ToList();

        
        return Task.FromResult<IEnumerable<Attendance>>(attendancesBeforePaging.ToList());


    }
    
    public IQueryable<Attendance> GetAttendances(AttendanceResourceParameters 
        attendanceResourceParameters)
    {
        
        var collection = _context.Attendances
                .Include(a=>a.Location)
                .Include(a=>a.User)
            as IQueryable<Attendance>;



        if ((attendanceResourceParameters.SearchQuery is not null))
        {
            // trim & ignore casing
            var queryForWhereClause = attendanceResourceParameters.SearchQuery
                .Trim().ToLowerInvariant();

            // get property mapping dictionary
            collection = collection
                .Where(a => a.Location.Name.Contains(queryForWhereClause) 
                            || a.User.FullName.ToLowerInvariant().Contains(queryForWhereClause) 
                            || a.User.Email.ToLowerInvariant().Contains(queryForWhereClause));

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