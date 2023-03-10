namespace AMS.Domain.Entities.Authentication;

public class Role : IdentityRole<Guid>
{
    public Role(string roleName)
    {
        this.Name = roleName;
    }

    public Role() { }
}