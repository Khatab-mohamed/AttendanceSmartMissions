namespace AMS.Application.DataTransferObjects;

public class LocationDto
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int AllowedDistance { get; set; }
    public bool IsPublic { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Guid ModifiedBy { get; set; }

    public LocationDto(
        Guid id,
        DateTime startDate,
        DateTime endDate,
        double latitude,
        double longitude,
        int allowedDistance,
        bool isPublic, bool isActive, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
        Latitude = latitude;
        Longitude = longitude;
        AllowedDistance = allowedDistance;
        IsPublic = isPublic;
        IsActive = isActive;
        CreatedOn = createdOn;
        CreatedBy = createdBy;
        ModifiedOn = modifiedOn;
        ModifiedBy = modifiedBy;
    }

    public LocationDto()
    {
        
    }
    public LocationDto(bool isActive, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy)
    {
        IsActive = isActive;
        CreatedOn = createdOn;
        CreatedBy = createdBy;
        ModifiedOn = modifiedOn;
        ModifiedBy = modifiedBy;
    }

}