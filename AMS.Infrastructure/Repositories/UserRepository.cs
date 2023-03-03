
using AMS.Infrastructure.Persistence;

namespace AMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;

        public IEnumerable<ApplicationUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> Users(IEnumerable<Guid> userIds)
        {
            throw new NotImplementedException();
        }

        public void AddUser(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
            {
                throw new ArgumentNullException(nameof(applicationUser));
            }


            _context.Users.Add(applicationUser);
        }

        public void DeleteAuthor(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }

        public void UpdateAuthor(ApplicationUser applicationUser)
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
