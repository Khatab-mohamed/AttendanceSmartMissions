namespace AMS.Application.DTOs.Attendance;

public class CreateAttendance
{
    [Required]
    public AttendanceType Type { get; set; }
    [Required]
    public Guid LocationId { get; set; }
}