namespace AMS.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByName(string name);
        Task<User> GetUserById(Guid name);
        bool SaveAsync();
        Task<IEnumerable<User>> GetAll();
    }
   
}
