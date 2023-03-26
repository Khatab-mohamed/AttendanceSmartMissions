namespace AMS.Application.DTOs.Attendance;

public class AttendanceDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public Guid LocationId { get; set; }
    public DateTime CreatedOn { get; set; }
    public string Location { get; set; }

    public AttendanceType Type { get; set; }
}