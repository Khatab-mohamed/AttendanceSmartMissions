
namespace AMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;

        public bool SaveAsync()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
