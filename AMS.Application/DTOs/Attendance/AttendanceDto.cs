using AMS.Domain.Entities.Helpers;

namespace AMS.Application.DTOs.Attendance;

public class AttendanceDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid LocationId { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? Location { get; set; }

    public AttendanceType Type { get; set; }
}