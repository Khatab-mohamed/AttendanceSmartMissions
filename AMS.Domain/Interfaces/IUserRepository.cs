namespace AMS.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByName(string name);
        bool SaveAsync();
        Task<IEnumerable<User>> GetAll();
    }
   
}
