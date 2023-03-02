namespace AMS.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        //PagedList<User> GetUsers(UserResourceParameters authorsResourceParameters);
        User GetUser(Guid userId);
        IEnumerable<User> Users(IEnumerable<Guid> userIds);
        void AddUser(User user);
        void DeleteAuthor(User user);
        void UpdateAuthor(User user);
        bool AuthorExists(Guid userId);
        bool Save();
    }
   
}
