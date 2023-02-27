namespace AMS.Domain.Entities.Common;

public class Base
{
    public Base()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Guid ModifiedBy { get; set; }
}