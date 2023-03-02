
using AMS.Infrastructure.Persistence;

namespace AMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Users(IEnumerable<Guid> userIds)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }


            _context.Users.Add(user);
        }

        public void DeleteAuthor(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateAuthor(User user)
        {
            throw new NotImplementedException();
        }

        public bool AuthorExists(Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
