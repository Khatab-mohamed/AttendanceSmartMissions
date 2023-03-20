namespace AMS.Domain.ResourceParameters.Attendances;

public class AttendanceResourceParameters
{
    public string? SearchQuery { get; set; }
    const int maxPageSize = 30;
    public int PageNumber { get; set; } = 1;
    public int _pageSize = 10;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > maxPageSize ? maxPageSize : value;
    }

    public DateTime? From { get; set; }
    public DateTime? To { get; set; }


}