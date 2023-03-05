namespace AMS.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByName(string name);
        bool SaveAsync();
    }
   
}
