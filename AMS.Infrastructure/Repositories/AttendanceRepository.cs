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

    public async Task<IEnumerable<Attendance>> GetAttendances(Guid userId)
    {
        var attendances = await _context.Attendances
            .Where(a => a.UserId == userId)
            .OrderBy(a => a.CreatedOn).Include(a=>a.Location).ToListAsync();
        return attendances;
    }

    public bool SaveAsync()
    {
        return (_context.SaveChanges() >= 0);
    }

}