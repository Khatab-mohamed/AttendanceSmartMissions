namespace AMS.Application.Common.Authentication;

public static class CustomRoles
{
    public const string SuperAdmin = "Super Admin";
    public const string Admin = "Admin";
    public const string User = "User";
    public const string SuperAdminOrAdmin = SuperAdmin + "," + Admin;
}
