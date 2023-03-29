using AMS.Domain.Entities.Helpers;
using AMS.Domain.Helpers;

namespace AMS.Infrastructure.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    #region Constructor



    private readonly ApplicationDbContext _context;
    public AttendanceRepository(ApplicationDbContext context) => _context = context;


    #endregion

    public async Task CreateAsync(Attendance attendance)
    {// Specify the time zone info for the Riyadh time zone
        var riyadhTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time");

        // Get the current date and time in the Riyadh time zone
        var createdOnRiyadh = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, riyadhTimeZone);

        // Create a new attendance object with the captured CreatedOn time
        attendance.CreatedOn = createdOnRiyadh.DateTime.AddHours(-1);
        await _context.Attendances.AddAsync(attendance);
    }

    public Task<IEnumerable<Attendance>> GetMyAttendances(Guid userId)
    {
        var attendancesBeforePaging = _context.Attendances
            .Include(a => a.Location)
            .Where(a => a.UserId == userId)
            .OrderBy(a => a.CreatedOn).ToList();


        return Task.FromResult<IEnumerable<Attendance>>(attendancesBeforePaging.ToList());


    }

    public IQueryable<Attendance> GetAttendances(AttendanceResourceParameters
        attendanceResourceParameters)
    {

        var collection = _context.Attendances
                .Include(a => a.Location)
                .Include(a => a.User).OrderBy(a => a.CreatedOn)
            as IQueryable<Attendance>;



        if ((attendanceResourceParameters.SearchQuery is not null))
        {
            // trim & ignore casing
            var queryForWhereClause = attendanceResourceParameters.SearchQuery
                .Trim().ToLowerInvariant();

            // get property mapping dictionary
            collection = collection
                .Where(a => a.Location.Name.Contains(queryForWhereClause));
            /*|| a.User.FullName.ToLowerInvariant().Contains(queryForWhereClause) 
            || a.User.Email.ToLowerInvariant().Contains(queryForWhereClause))*/

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
    public async Task<IEnumerable<WorkHistory>> GetWorkHistory(Guid userId)
    {
        // Set the time period to report on (e.g., last 30 days)
        DateTime startDate = DateTime.Now.AddDays(-30);
        DateTime endDate = DateTime.Now;

        // Get the attendance records for the specified user and time period
        var attendanceRecords = await _context.Attendances
            .Where(a => a.UserId == userId && a.CreatedOn >= startDate && a.CreatedOn <= endDate)
            .OrderBy(a => a.CreatedOn)
            .ToListAsync();

        // Group the attendance records by date
        var attendanceByDate = attendanceRecords.GroupBy(a => a.CreatedOn.Date);

        // Calculate the total hours worked for each date
        var workHistory = new List<WorkHistory>();
        foreach (var group in attendanceByDate)
        {
            DateTime date = group.Key;

            float totalHours = 0;
            Attendance lastCheckOut = null;
            foreach (Attendance attendance in group.OrderBy(a => a.CreatedOn))
            {
                if (attendance.AttendanceType == AttendanceType.CheckIn)
                {
                    // Check-in record
                    lastCheckOut = null; // Reset the last check-out record
                }
                else if (attendance.AttendanceType == AttendanceType.CheckOut)
                {
                    // Check-out record
                    if (lastCheckOut != null)
                    {
                        // Calculate the duration between the last check-out and the current check-in
                        TimeSpan duration = attendance.CreatedOn - lastCheckOut.CreatedOn;
                        totalHours += (float)duration.TotalHours;
                    }
                    lastCheckOut = attendance; // Store the check-out record
                }
            }

            workHistory.Add(new WorkHistory { Date = date, WorkingHours = totalHours });
        }

        return workHistory;
    }
}
