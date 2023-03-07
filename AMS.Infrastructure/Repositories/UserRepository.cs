
namespace AMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;

        public async Task<User> GetUserByName(string name)
        {
            var user = await  _context.Users.FirstAsync(u=>u.UserName == name);
            return user;
        }

        public bool SaveAsync()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
          return  await _context.Users.ToListAsync();
        }
    }
}
