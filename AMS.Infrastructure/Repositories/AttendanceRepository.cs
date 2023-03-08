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

    public bool SaveAsync()
    {
        return (_context.SaveChanges() >= 0);
    }

}