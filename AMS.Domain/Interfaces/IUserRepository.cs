namespace AMS.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();
        //PagedList<ApplicationUser> GetUsers(UserResourceParameters authorsResourceParameters);
        ApplicationUser GetUser(Guid userId);
        IEnumerable<ApplicationUser> Users(IEnumerable<Guid> userIds);
        void AddUser(ApplicationUser applicationUser);
        void DeleteAuthor(ApplicationUser applicationUser);
        void UpdateAuthor(ApplicationUser applicationUser);
        bool AuthorExists(Guid userId);
        bool Save();
    }
   
}
